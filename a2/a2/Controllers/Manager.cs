using a2.Data;
using a2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Numerics;
using System.Web;

// ************************************************************************************
// WEB524 Project Template V1 == 2231-c60b75ee-c962-421e-a18a-8ce1cdcbc4b9
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace a2.Controllers
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

                cfg.CreateMap<Track, TrackBaseViewModel>();

                // Attention 03 - Will use the mapping above to map the associated Team object
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
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

        // ####################################################################################
        // TRACK 

        public IEnumerable<TrackWithDetailViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(ds.Tracks.OrderBy(track => track.Name))
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetBluesJazz()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Where(t => t.GenreId == 2 || t.GenreId == 6)
                .OrderBy(t => t.GenreId).ThenBy(t => t.Name));
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetCantrellStaley()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Where(t => t.Composer.Contains("Jerry Cantrell") && t.Composer.Contains("Layne Staley"))
                .OrderBy(t => t.Composer).ThenBy(t => t.Name));
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Longest()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.OrderBy(t => t.Milliseconds).Take(50).OrderBy(t => t.Name));
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Smallest()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.OrderBy(t => t.Bytes).Take(50).OrderBy(t => t.Name));
        }
    }
}