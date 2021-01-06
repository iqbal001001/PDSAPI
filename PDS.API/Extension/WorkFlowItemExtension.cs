using Newtonsoft.Json;
using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class WorkFlowItemExtension
    {
        public static WorkFlowItemDto ToDto(this WorkFlowItem item)
        {
            try
            {
                var dto = new WorkFlowItemDto
                {
                    Obj = JsonConvert.DeserializeObject(item.Json, System.Type.GetType(item.Type + "Dto")),
                    Type = item.Type.Insert(item.Type.Length, "Dto"),
                    ParentType = item.ParentType?.Insert(item.ParentType.Length, "Dto"),
                    ParentId = item.ParentId,
                    API = item.API,
                    ObjId = item.ObjId,
                    ApprovalStatus
                    = (ApprovalStatusDto)Enum.Parse(typeof(ApprovalStatusDto), item.ApprovalStatus.ToString(), true)
                };
                ((IData)item).ToDto((IDataDto)dto);
                return dto;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public static class WorkFlowItemDtoExtension
    {
        public static WorkFlowItem ToDomain(this WorkFlowItemDto item, WorkFlowItem originalItem = null)
        {

            if (originalItem != null && originalItem.Id == item.Id)
            {
                originalItem.Json = JsonConvert.SerializeObject(item.Obj);
                originalItem.Type = item.Type.Replace("Dto", "");
                originalItem.ParentType = item.ParentType.Replace("Dto", "");
                originalItem.ParentId = item.ParentId;
                originalItem.API = item.API;
                originalItem.ObjId = item.ObjId;
                originalItem.ApprovalStatus
                    = (ApprovalStatus)Enum.Parse(typeof(ApprovalStatus), item.ApprovalStatus.ToString(), true);

                ((IDataDto)item).ToDomain((IData)originalItem);
                return originalItem;
            }

            var data = new WorkFlowItem
            {
                Json = JsonConvert.SerializeObject(item.Obj),
                Type = item.Type.Replace("Dto", ""),
                ParentType = item.ParentType.Replace("Dto", ""),
                ParentId = item.ParentId,
                API = item.API,
                ObjId = item.ObjId,
                ApprovalStatus
                = (ApprovalStatus)Enum.Parse(typeof(ApprovalStatus), item.ApprovalStatus.ToString(), true)
            };

            ((IDataDto)item).ToDomain((IData)data);
            return data;
        }
    }
}