using System.Collections.Generic;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service.Models;
using Project = DoffingDesign.DAL.EntityModels.Project;
using ProjectItem = DoffingDesign.DAL.EntityModels.ProjectItem;

namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoffingDesign.DAL.EntityModels.DoffingDotComModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
