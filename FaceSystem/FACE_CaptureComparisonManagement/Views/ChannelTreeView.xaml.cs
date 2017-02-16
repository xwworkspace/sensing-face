using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FACE_CaptureComparisonManagement.ViewModels;
using Telerik.Windows.Controls;


namespace FACE_CaptureComparisonManagement.Views
{
    [Export]
    public partial class ChannelTreeView : UserControl
    {
        public ChannelTreeView()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = true)]
        public ViewModel viewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }

        private void item_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadTreeView view = (RadTreeView)sender;

            var item = view.SelectedItem;
        }
    }

    public class Animal
    {
        public Animal()
        {
        }

        public Animal(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }
        public string Name
        {
            get;
            set;
        }
        public Category Category
        {
            get;
            set;
        }
        public IEnumerable<Animal> AnimalList
        {
            get
            {
                List<Animal> animalList = new List<Animal>();
                animalList.Add(new Animal("California Newt", Category.Amphibians));
                animalList.Add(new Animal("Giant Panda", Category.Bears));
                animalList.Add(new Animal("Coyote", Category.Canines));
                animalList.Add(new Animal("Golden Silk Spader", Category.Spiders));
                animalList.Add(new Animal("Mandrill", Category.Primates));
                animalList.Add(new Animal("Black Bear", Category.Bears));
                animalList.Add(new Animal("Jaguar", Category.BigCats));
                animalList.Add(new Animal("Bornean Gibbon", Category.Primates));
                animalList.Add(new Animal("African Wildcat", Category.BigCats));
                animalList.Add(new Animal("Artic Fox", Category.Canines));
                animalList.Add(new Animal("Tomato Frog", Category.Amphibians));
                animalList.Add(new Animal("Grizzly Bear", Category.Bears));
                animalList.Add(new Animal("Dingo", Category.Canines));
                animalList.Add(new Animal("Gorilla", Category.Primates));
                animalList.Add(new Animal("Green Tree Frog", Category.Amphibians));
                animalList.Add(new Animal("Bald Vakari", Category.Primates));
                animalList.Add(new Animal("Polar Bear", Category.Bears));
                animalList.Add(new Animal("Black Widow Spider", Category.Spiders));
                animalList.Add(new Animal("Bat-Eared Fox", Category.Canines));
                animalList.Add(new Animal("Cheetah", Category.BigCats));
                return animalList.AsEnumerable();
            }
        }
    }

    public enum Category
    {
        Amphibians,
        Bears,
        Canines,
        Spiders,
        Primates,
        BigCats
    }

    public class LeagueCollection : ObservableCollection<League>
    {
        public LeagueCollection()
        {
            League l;
            League ll;
            Division d;
            
            Add(l = new League("League A"));
            l.Leagues.Add(ll = new League("League AA"));
            ll.Divisions.Add((d = new Division("Division A")));
            //l.Divisions.Add((d = new Division("Division A")));
            d.Teams.Add(new Team("Team I"));
            d.Teams.Add(new Team("Team II"));
            d.Teams.Add(new Team("Team III"));
            d.Teams.Add(new Team("Team IV"));
            d.Teams.Add(new Team("Team V"));
            ll.Divisions.Add((d = new Division("Division B")));
            d.Teams.Add(new Team("Team Blue"));
            d.Teams.Add(new Team("Team Red"));
            d.Teams.Add(new Team("Team Yellow"));
            d.Teams.Add(new Team("Team Green"));
            d.Teams.Add(new Team("Team Orange"));
            ll.Divisions.Add((d = new Division("Division C")));
            d.Teams.Add(new Team("Team East"));
            d.Teams.Add(new Team("Team West"));
            d.Teams.Add(new Team("Team North"));
            d.Teams.Add(new Team("Team South"));

            Add(l = new League("League B"));
            l.Leagues.Add(ll = new League("League AA"));
            ll.Divisions.Add((d = new Division("Division A")));
            d.Teams.Add(new Team("Team 1"));
            d.Teams.Add(new Team("Team 2"));
            d.Teams.Add(new Team("Team 3"));
            d.Teams.Add(new Team("Team 4"));
            d.Teams.Add(new Team("Team 5"));
            ll.Divisions.Add((d = new Division("Division B")));
            d.Teams.Add(new Team("Team Diamond"));
            d.Teams.Add(new Team("Team Heart"));
            d.Teams.Add(new Team("Team Club"));
            d.Teams.Add(new Team("Team Spade"));
            ll.Divisions.Add((d = new Division("Division C")));
            d.Teams.Add(new Team("Team Alpha"));
            d.Teams.Add(new Team("Team Beta"));
            d.Teams.Add(new Team("Team Gamma"));
            d.Teams.Add(new Team("Team Delta"));
            d.Teams.Add(new Team("Team Epsilon"));
        }

    }

    public class League
    {
        public League(string name)
        {
            this.Name = name;
            this.Divisions = new ObservableCollection<Division>();
            this.Leagues = new ObservableCollection<League>();
        }
        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<League> Leagues
        {
            get;
            set;
        }
        public ObservableCollection<Division> Divisions
        {
            get;
            set;
        }
    }
    public class Division
    {
        public Division(string name)
        {
            this.Name = name;
            this.Teams = new ObservableCollection<Team>();
        }
        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<Team> Teams
        {
            get;
            set;
        }
    }

    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }
}
