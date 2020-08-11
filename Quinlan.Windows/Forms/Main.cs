using Quinlan.Domain.Models;
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
    public partial class Main : Form
    {
        private int childFormNumber = 0;

        private ICrudService<Quinlan.Domain.Models.Card> _cardService;
        private ICrudService<Quinlan.Domain.Models.Container> _containerService;
        private ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public Main(ICrudService<Quinlan.Domain.Models.Container> containerService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService, ICrudService<Quinlan.Domain.Models.Card> cardService)
        {
            InitializeComponent();

            _containerService = containerService;
            _cardSearchService = cardSearchService;
            _cardService = cardService;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            ContainerAddDialog addContainerDialog = new ContainerAddDialog(_containerService);

            if (addContainerDialog.ShowDialog(this) == DialogResult.OK)
            {

                int _containerId = addContainerDialog.ContainerId;

                ContainerForm containerForm = new ContainerForm(_containerService, _cardService, _cardSearchService, _containerId);
                containerForm.MdiParent = this;
                containerForm.Text = "Container Name";
                containerForm.Show();
            }

        }

        private void OpenFile(object sender, EventArgs e)
        {
            ContainerOpenDialog openContainerDialog = new ContainerOpenDialog(_containerService);

            if (openContainerDialog.ShowDialog(this) == DialogResult.OK)
            {
                int _containerId = openContainerDialog.ContainerId;

                ContainerForm containerForm = new ContainerForm(_containerService, _cardService, _cardSearchService, _containerId);
                containerForm.MdiParent = this;
                containerForm.Text = "Container Name";
                containerForm.Show();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
