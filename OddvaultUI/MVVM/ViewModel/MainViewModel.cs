using Oddvault.Core;
using Oddvault.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oddvault.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewComand { get; set; }
        public RelayCommand MonstresViewComand { get; set; }
        public RelayCommand ItemsViewComand { get; set; }
        public RelayCommand RecettesViewComand { get; set; }
        public RelayCommand JoueursViewComand { get; set; }
        public RelayCommand DonjonViewComand { get; set; }


        public HomeViewModel HomeVm { get; set; }
        public MonstresViewModel Mob { get; set; }
        public ItemsViewModel Item { get; set; }
        public RecettesViewModel Recet { get; set; }
        public JoueursViewModel Joueur { get; set; }
        public DonjonViewModel Donjon { get; set; }



        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
                }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            Mob = new MonstresViewModel();
            Item = new ItemsViewModel();
            Recet = new RecettesViewModel();
            Joueur = new JoueursViewModel();
            Donjon = new DonjonViewModel();


            currentView = HomeVm;


            HomeViewComand = new RelayCommand(o =>
            {
                currentView = HomeVm;
            });
            MonstresViewComand = new RelayCommand(o =>
            {
                currentView = Mob;
            });
            ItemsViewComand = new RelayCommand(o =>
            {
                currentView = Item;
            });
            RecettesViewComand = new RelayCommand(o =>
            {
                currentView = Recet;
            });
            JoueursViewComand = new RelayCommand(o =>
            {
                currentView = Joueur;
            });
            DonjonViewComand = new RelayCommand(o =>
            {
                currentView = Donjon;
            });
        }
    }
}