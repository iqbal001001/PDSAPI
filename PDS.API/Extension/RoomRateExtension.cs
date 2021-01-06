using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class RoomRateExtension
    {
        public static RoomRateDto ToDto(this RoomRate roomRate)
        {
            var dto = new RoomRateDto
            {
                ProductLineId = roomRate.ProductLineId,
                HospitalTypeId = roomRate.HospitalTypeId,
                AccessTypeId = roomRate.AccessTypeId,
                RoomRateTypeId = roomRate.TypeId
            };

            ((IData)roomRate).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class RoomRateDtoExtension
    {
        public static RoomRate ToDomain(this RoomRateDto roomRate, RoomRate originalRoomRate = null)
        {
            if (originalRoomRate != null && originalRoomRate.Id == roomRate.Id)
            {
                originalRoomRate.ProductLineId = roomRate.ProductLineId;
                originalRoomRate.HospitalTypeId = roomRate.HospitalTypeId;
                originalRoomRate.AccessTypeId = roomRate.AccessTypeId;
                originalRoomRate.TypeId = roomRate.RoomRateTypeId;

                ((IDataDto)roomRate).ToDomain((IData)originalRoomRate);
                return originalRoomRate;
            }

            var data = new RoomRate
            {
                ProductLineId = roomRate.ProductLineId,
                HospitalTypeId = roomRate.HospitalTypeId,
                AccessTypeId = roomRate.AccessTypeId,
                TypeId = roomRate.RoomRateTypeId
            };

            ((IDataDto)roomRate).ToDomain((IData)data);
            return data;
        }

    }
        public static class HospitalTypeExtension
        {
            public static HospitalTypeDto ToDto(this HospitalType hospitalType)
            {
                var dto = new HospitalTypeDto
                {
                };

                ((IData)hospitalType).ToDto((IDataDto)dto);
                return dto;
            }
        }

        public static class HospitalTypeDtoExtension
        {
            public static HospitalType ToDomain(this HospitalTypeDto hospitalType, HospitalType originalHospitalType = null)
            {
                if (originalHospitalType != null && originalHospitalType.Id == hospitalType.Id)
                {
                    ((IDataDto)hospitalType).ToDomain((IData)originalHospitalType);
                    return originalHospitalType;
                }

                var data = new HospitalType
                {
                };

                ((IDataDto)hospitalType).ToDomain((IData)data);
                return data;
            }
        }

    public static class AccessTypeExtension
    {
        public static AccessTypeDto ToDto(this AccessType hospitalType)
        {
            var dto = new AccessTypeDto
            {
            };

            ((IData)hospitalType).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class AccessTypeDtoExtension
    {
        public static AccessType ToDomain(this AccessTypeDto accessType, AccessType originalHospitalType = null)
        {
            if (originalHospitalType != null && originalHospitalType.Id == accessType.Id)
            {
                ((IDataDto)accessType).ToDomain((IData)originalHospitalType);
                return originalHospitalType;
            }

            var data = new AccessType
            {
            };

            ((IDataDto)accessType).ToDomain((IData)data);
            return data;
        }
    }

    public static class RoomRateTypeExtension
    {
        public static RoomRateTypeDto ToDto(this RoomRateType hospitalType)
        {
            var dto = new RoomRateTypeDto
            {
            };

            ((IData)hospitalType).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class RoomRateTypeDtoExtension
    {
        public static RoomRateType ToDomain(this RoomRateTypeDto roomRateType, RoomRateType originalRoomRateTypee = null)
        {
            if (originalRoomRateTypee != null && originalRoomRateTypee.Id == roomRateType.Id)
            {
                ((IDataDto)roomRateType).ToDomain((IData)originalRoomRateTypee);
                return originalRoomRateTypee;
            }

            var data = new RoomRateType
            {
            };

            ((IDataDto)roomRateType).ToDomain((IData)data);
            return data;
        }
    }

}