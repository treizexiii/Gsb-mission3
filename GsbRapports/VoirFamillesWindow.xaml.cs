using System.Collections.Generic;
using System.Net;
using System.Windows;
using dllRapportVisites;
using Newtonsoft.Json;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour VoirFamillesWindow.xaml
    /// </summary>
    public partial class VoirFamillesWindow : Window
    {
        private readonly WebClient wb;
        private readonly Secretaire laSecretaire;
        private readonly string site;

        public VoirFamillesWindow(WebClient wb, Secretaire s, string site)
        {
            InitializeComponent();
            this.wb = wb;
            laSecretaire = s;
            this.site = site;

            string url = this.site + "familles?ticket=" + laSecretaire.getHashTicketMdp();
            string reponse = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(reponse);
            string familles = d.familles.ToString();
            string ticket = d.ticket;
            List<Famille> f = JsonConvert.DeserializeObject<List<Famille>>(familles);
            laSecretaire.ticket = ticket;
            dtg_famille.ItemsSource = f;
        }
    }
}
