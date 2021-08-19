using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ProjetPoulinaDomain.Command;
using ProjetPoulinaDomain.Handler;
using ProjetPoulinaDomain.Querie;
using ProjetPoulinaDomain.Interface;
using ProjetPoulinaDomain.Models;
using GestionUtilisateur.Data.Repository;

namespace PrjPoulina.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Amortissement
            services.AddTransient<IRepository<Amortissement>, Repository<Amortissement>>();
            services.AddTransient<IRequestHandler<PostGeneric<Amortissement>, string>, PostGenericHandler<Amortissement>>();
            services.AddTransient<IRequestHandler<PutGeneric<Amortissement>, string>, PutGenericHandler<Amortissement>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Amortissement>, string>, DeleteGenericHandler<Amortissement>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Amortissement>, IEnumerable<Amortissement>>, GetAllGenericHandler<Amortissement>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Amortissement>, Amortissement>, GetGenericByIDHandler<Amortissement>>();

            //Centre
            services.AddTransient<IRepository<Centre>, Repository<Centre>>();
            services.AddTransient<IRequestHandler<PostGeneric<Centre>, string>, PostGenericHandler<Centre>>();
            services.AddTransient<IRequestHandler<PutGeneric<Centre>, string>, PutGenericHandler<Centre>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Centre>, string>, DeleteGenericHandler<Centre>>();
            
            services.AddTransient<IRequestHandler<GetAllGeneric<Centre>, IEnumerable<Centre>>, GetAllGenericHandler<Centre>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Centre>, Centre>, GetGenericByIDHandler<Centre>>();

            //Speculation
            services.AddTransient<IRepository<Speculation>, Repository<Speculation>>();
            services.AddTransient<IRequestHandler<PostGeneric<Speculation>, string>, PostGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<PutGeneric<Speculation>, string>, PutGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Speculation>, string>, DeleteGenericHandler<Speculation>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Speculation>, IEnumerable<Speculation>>, GetAllGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Speculation>, Speculation>, GetGenericByIDHandler<Speculation>>();

            //Stock
            services.AddTransient<IRepository<Stock>, Repository<Stock>>();
            services.AddTransient<IRequestHandler<PostGeneric<Stock>, string>, PostGenericHandler<Stock>>();
            services.AddTransient<IRequestHandler<PutGeneric<Stock>, string>, PutGenericHandler<Stock>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Stock>, string>, DeleteGenericHandler<Stock>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Stock>, IEnumerable<Stock>>, GetAllGenericHandler<Stock>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Stock>, Stock>, GetGenericByIDHandler<Stock>>();

            //TraitementStock
            services.AddTransient<IRepository<TraitementStock>, Repository<TraitementStock>>();
            services.AddTransient<IRequestHandler<PostGeneric<TraitementStock>, string>, PostGenericHandler<TraitementStock>>();
            services.AddTransient<IRequestHandler<PutGeneric<TraitementStock>, string>, PutGenericHandler<TraitementStock>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<TraitementStock>, string>, DeleteGenericHandler<TraitementStock>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<TraitementStock>, IEnumerable<TraitementStock>>, GetAllGenericHandler<TraitementStock>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<TraitementStock>, TraitementStock>, GetGenericByIDHandler<TraitementStock>>();


            //Speculation_centre
            services.AddTransient<IRepository<Speculation_centre>, Repository<Speculation_centre>>();
            services.AddTransient<IRequestHandler<PostGeneric<Speculation_centre>, string>, PostGenericHandler<Speculation_centre>>();
            services.AddTransient<IRequestHandler<PutGeneric<Speculation_centre>, string>, PutGenericHandler<Speculation_centre>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Speculation_centre>, string>, DeleteGenericHandler<Speculation_centre>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Speculation_centre>, IEnumerable<Speculation_centre>>, GetAllGenericHandler<Speculation_centre>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Speculation_centre>, Speculation_centre>, GetGenericByIDHandler<Speculation_centre>>();

            //Reforme
            services.AddTransient<IRepository<Reforme>, Repository<Reforme>>();
            services.AddTransient<IRequestHandler<PostGeneric<Reforme>, string>, PostGenericHandler<Reforme>>();
            services.AddTransient<IRequestHandler<PutGeneric<Reforme>, string>, PutGenericHandler<Reforme>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Reforme>, string>, DeleteGenericHandler<Reforme>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Reforme>, IEnumerable<Reforme>>, GetAllGenericHandler<Reforme>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Reforme>, Reforme>, GetGenericByIDHandler<Reforme>>();

            //Oeuf
            services.AddTransient<IRepository<Oeuf>, Repository<Oeuf>>();
            services.AddTransient<IRequestHandler<PostGeneric<Oeuf>, string>, PostGenericHandler<Oeuf>>();
            services.AddTransient<IRequestHandler<PutGeneric<Oeuf>, string>, PutGenericHandler<Oeuf>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Oeuf>, string>, DeleteGenericHandler<Oeuf>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Oeuf>, IEnumerable<Oeuf>>, GetAllGenericHandler<Oeuf>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Oeuf>, Oeuf>, GetGenericByIDHandler<Oeuf>>();

            //Marche
            services.AddTransient<IRepository<Marche>, Repository<Marche>>();
            services.AddTransient<IRequestHandler<PostGeneric<Marche>, string>, PostGenericHandler<Marche>>();
            services.AddTransient<IRequestHandler<PutGeneric<Marche>, string>, PutGenericHandler<Marche>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Marche>, string>, DeleteGenericHandler<Marche>>();

            services.AddTransient<IRequestHandler<GetAllGeneric<Marche>, IEnumerable<Marche>>, GetAllGenericHandler<Marche>>();
            services.AddTransient<IRequestHandler<GetByIDGeneric<Marche>, Marche>, GetGenericByIDHandler<Marche>>();

        }
    }
}
