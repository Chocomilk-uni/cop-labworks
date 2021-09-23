using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonVisualComponentsLibrary
{
    public partial class BinaryRestoreComponent : Component
    {
        public BinaryRestoreComponent()
        {
            InitializeComponent();
        }

        public BinaryRestoreComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
