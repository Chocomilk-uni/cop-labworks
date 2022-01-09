﻿using LibraryBusinessLogic.PluginLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace LibraryBusinessLogic.PluginLogic.Managers
{
    public class ReportPluginManager
    {
        [ImportMany(typeof(IReportBuilder))]
        private List<IReportBuilder> Plugins { get; set; }

        public readonly Dictionary<string, IReportBuilder> plugins = new Dictionary<string, IReportBuilder>();
        public List<string> Headers { get; set; }
        public ReportPluginManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            var pa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pa)) Directory.CreateDirectory(pa);
            catalog.Catalogs.Add(new DirectoryCatalog(pa));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            Headers = new List<string>();
            Plugins.ForEach(x =>
            {
                if (!plugins.ContainsKey(x.PluginType))
                    plugins.Add(x.PluginType, x);
            });
            Headers.AddRange(plugins.Keys.ToList());
        }
    }
}