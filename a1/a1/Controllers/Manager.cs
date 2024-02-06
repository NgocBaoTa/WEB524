using a1.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using a1.Models;

// ************************************************************************************
// WEB524 Project Template V1 == 2231-37358bdc-7b44-4100-8c4e-0ff4381a8cce
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace a1.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Venue, VenueBaseViewModel>();

                cfg.CreateMap<VenueAddViewModel, Venue>();

                cfg.CreateMap<VenueEditViewModel, Venue>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(ds.Venues.OrderBy(v => v.Company));
        }

        public VenueBaseViewModel VenueGetById(int id)
        {
            // Using the SingleOrDefault method
            var venue = ds.Venues.SingleOrDefault(v => v.VenueId == id);

            // Return the result, or null if not found
            return (venue == null) ? null : mapper.Map<Venue, VenueBaseViewModel>(venue);
        }

        public VenueBaseViewModel VenueAdd(VenueAddViewModel newVenue)
        {
            // Add the new item.
            var addedItem = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(newVenue));
            ds.SaveChanges();

            // If successful, return the added item (mapped to a view model class).
            return addedItem == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addedItem);
        }

        public VenueBaseViewModel VenueEdit(VenueEditViewModel editedVenue)
        {
            var venue = ds.Venues.Find(editedVenue.VenueId);

            if (venue == null) 
            {
                return null;
            }

            mapper.Map(editedVenue, venue);
            ds.SaveChanges();

            // Return the edited object back to the controller
            var editedViewModel = mapper.Map<VenueBaseViewModel>(venue);
            return editedViewModel;
        }

        public bool VenueDelete(int id)
        {
            var venue = ds.Venues.Find(id);

            if (venue == null)
            {
                return false;
            }

            ds.Venues.Remove(venue);
            ds.SaveChanges();

            return true;
        }
    }
}