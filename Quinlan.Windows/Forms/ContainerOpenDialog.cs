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
    public partial class ContainerOpenDialog : Form
    {
        private ICrudService<Quinlan.Domain.Models.Container> _containerService;

        public int ContainerId { get; set; } 

        public ContainerOpenDialog(ICrudService<Quinlan.Domain.Models.Container> containerService)
        {
            InitializeComponent();

            _containerService = containerService;

            var containers = _containerService.Get();

            foreach (var container in containers)
            {
                this.containerListBox.Items.Add(container.Name);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ContainerId = 1;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
