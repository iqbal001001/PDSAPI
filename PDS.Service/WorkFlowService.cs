using Newtonsoft.Json;
using PDS.Data.Repository;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace PDS.Service
{
    public class WorkFlowItemService : BaseService<WorkFlowItem>
    {
        private static readonly HttpClient client = new HttpClient();
        public WorkFlowItemService()
        {
            _repo = new WorkFlowItemRepo();
        }

        public List<WorkFlowItem> GetItems(string type, ApprovalStatus status)
        {
            return _repo.Get(x => x.Type == type && x.ApprovalStatus == status).ToList();
        }

        public List<WorkFlowItem> GetItemsForParent(string type, int Id, ApprovalStatus status, string childtype, int ObjId)
        {
            var items = _repo
                .Get(x => x.ParentType == type && x.ParentId == Id && x.ApprovalStatus == status && x.Type == childtype) // && x.ObjId == ObjId)
                .ToList();
            return items;
        }

        public List<string> GetWorkFlowPendingItems(string Type, int ParentId, string childType)
        {

            var items =
                 GetItemsForParent(Type, ParentId, ApprovalStatus.Added, childType, 0)
                 .Select(x => x.Json)
                 .ToList(); ;
            return items;
        }
    public Guid? GetToken(int id)
        {
            return _repo.Get(x => x.Id == id).FirstOrDefault()?.ValiationToken; 
        }

        public override void Add(WorkFlowItem entity, bool save = true)
        {
            
            base.Add(entity);

            dynamic itemDto = JObject.Parse(entity.Json);
            itemDto.WorkFlowItemId = entity.Id;
            entity.Json = JsonConvert.SerializeObject(itemDto);
            base.Add(entity);
        }

        public WorkFlowItem AddAndTrigger(WorkFlowItem entity, bool save = true)
        {
            try
            {
                if (entity.ApprovalStatus == ApprovalStatus.Approved)
                {
                    var token = Guid.NewGuid();
                    entity.ValiationToken = token;
                    Add(entity);

                    dynamic itemDto = JObject.Parse(entity.Json);
                    itemDto.WorkFlowItemToken = token;
                    itemDto.WorkFlowItemId = entity.Id;
                    itemDto.ApprovalStatus = ApprovalStatus.Approved;

                    var content = new StringContent(JsonConvert.SerializeObject(itemDto), Encoding.UTF8, "application/json");

                    var response = client.PostAsync("http://localhost:54680/" + entity.API, content).Result;

                    response.EnsureSuccessStatusCode();

                    string data = response.Content.ReadAsStringAsync().Result;

                     itemDto = JObject.Parse(data); //JsonConvert.DeserializeObject(data, type);

                    entity.ObjId = itemDto.Id;
                    entity.ApprovalStatus = ApprovalStatus.Added;
                }
                Add(entity);
                
            }
            catch (Exception ex)
            {

            }
            return entity;
        }
    }
}
