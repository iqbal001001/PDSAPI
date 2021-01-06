using PDS.API.Dto;
using PDS.API.Extension;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Service
{
    public class WorkFlowItemDtoService : IDtoService<WorkFlowItem, WorkFlowItemDto>
    {
        public WorkFlowItemDto ToDto(WorkFlowItem entity)
        {
            return entity.ToDto();
        }

        public WorkFlowItem ToDomain(WorkFlowItemDto dto, WorkFlowItem originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
}