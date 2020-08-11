using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quinlan.Windows.Forms
{
    public partial class ContainerForm : Form
    {
        private ICrudService<Quinlan.Domain.Models.Container> _containerService;
        private ICrudService<Card> _cardService;
        private ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;

        private int _containerId;

        private CardSearchFilterOptions _availableFilterOptions;

        public ContainerForm(ICrudService<Quinlan.Domain.Models.Container> containerService, ICrudService<Card> cardService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService, int containerId)
        {
            InitializeComponent();

            _containerService = containerService;
            _cardService = cardService;
            _cardSearchService = cardSearchService;
            _containerId = containerId;

            var container = _containerService.Get(_containerId);
            labelContainerCards.Text = string.Format("Cards in {0}", container.Name);

            _availableFilterOptions = new CardSearchFilterOptions { NoContainerFlag = true };

            RefreshAvailable();
            RefreshContainer();        
        }
        private void RefreshContainer()
        {
            var containerCardSearch = _cardSearchService.Get(new CardSearchFilterOptions { ContainerId = _containerId });

            foreach (var card in containerCardSearch.Cards)
            {
                listBoxContainerCards.Items.Add(card.ToString());
            }
        }
        private void RefreshAvailable()
        {
            var noContainerCardSearch = _cardSearchService.Get(_availableFilterOptions);

            listBoxAvailableCards.Items.Clear();

            foreach (var card in noContainerCardSearch.Cards)
            {
                listBoxAvailableCards.Items.Add(card);
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (radioButtonBaseball.Checked) _availableFilterOptions.SportId = Quinlan.Data.Services.SportCodeService.Baseball.Id;
            if (radioButtonBasketball.Checked) _availableFilterOptions.SportId = Quinlan.Data.Services.SportCodeService.Basketball.Id;
            if (radioButtonFootball.Checked) _availableFilterOptions.SportId = Quinlan.Data.Services.SportCodeService.Football.Id;
            if (radioButtonHockey.Checked) _availableFilterOptions.SportId = Quinlan.Data.Services.SportCodeService.Hockey.Id;

            RefreshAvailable();
        }

        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableCards.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an available card.");
                return;  // how to do popup
            }

            Card card = (Card) listBoxAvailableCards.SelectedItem;
            card.Container = new Domain.Models.Container
            {
                Id = _containerId 
            };

            _cardService.Put(card.Id, card);


            listBoxAvailableCards.Items.Remove(card);
            listBoxContainerCards.Items.Add(card);
        }
    }
}
