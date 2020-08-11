using Quinlan.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quinlan.Windows.Forms
{
    public partial class ContainerAddDialog : Form
    {
        private ICrudService<Quinlan.Domain.Models.Container> _containerService;
        public int ContainerId { get; set; }
        public ContainerAddDialog(ICrudService<Quinlan.Domain.Models.Container> containerService)
        {
            InitializeComponent();

            _containerService = containerService;

            
        }
    }
}
