using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Api Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            // Api Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove Unselected Features
                    var removedFeatures = v.Features.Where(vf => vr.Features.Contains(vf.FeatureId));
                    foreach (var vf in removedFeatures)
                    {
                        v.Features.Remove(vf);
                    }

                    // Add New Features
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(vf => vf.FeatureId == id)).Select(id => new VehicleFeature() { FeatureId = id });
                    foreach (var vf in addedFeatures)
                    {
                        v.Features.Add(vf);
                    }
                });
        }
    }
}