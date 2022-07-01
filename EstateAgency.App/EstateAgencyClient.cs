using EstateAgency.App.Data;
using EstateAgency.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EstateAgency.App
{
    internal class EstateAgencyClient
    {
        private HttpClient _client;
        public EstateAgencyClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44325/");
        }
        internal void ListAllUnits()
        {
            Console.WriteLine("==== Unit List ====");
            var response = _client.GetAsync("api/unit").Result;
            if (response.IsSuccessStatusCode)
            {
                var units = JsonConvert.DeserializeObject<List<Unit>>(response.Content.ReadAsStringAsync().Result);
                ConsoleHelpers.PrintTable(units, ConsoleUtils.unitColumns, "Units List");
            }
            else
            {
                ConsoleHelpers.ErrorMessage("Errore durante recupero immobili.");
            }
            
        }

        internal void InsertUnit()
        {
            ConsoleHelpers.InfoMessage("=== Inserimento nuovo immobile ===");
            short sup = short.Parse(ConsoleHelpers.GetData("Inserire superficie"));
            byte vani = byte.Parse(ConsoleHelpers.GetData("Numero vani"));
            short year = short.Parse(ConsoleHelpers.GetData("Anno di fabbricazione"));
            decimal price = decimal.Parse(ConsoleHelpers.GetData("Prezzo"));
            int ownerId = int.Parse(ConsoleHelpers.GetData("Codice Proprietario"));
            int tipo = int.Parse(ConsoleHelpers.GetData("Tipo appartamento (1,2,3)"));
            var unit = new Unit
            {
                AnnoFab = year,
                DataIns = DateTime.Now,
                NumVani = vani,
                OwnerId = ownerId,
                Prezzo = price,
                Superficie = sup,
                Tipo = tipo,
                Status = 1
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(unit), Encoding.UTF8, "application/json");
            var response = _client.PostAsync("api/unit", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ConsoleHelpers.SuccessMessage("Inserimento avvenuto correttamente");
            }
            else
            {
                ConsoleHelpers.ErrorMessage("Errore durante inserimento unità.");
            }
        }

        internal void UpdateOnwer()
        {
            int ownerId = int.Parse(ConsoleHelpers.GetData("Inserire codice proprietario"));

            var response = _client.GetAsync($"api/owner/{ownerId}").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var owner = JsonConvert.DeserializeObject<Owner>(content);
                if (owner == null)
                {
                    ConsoleHelpers.ErrorMessage("Proprietario non trovato.");
                }
                else
                {
                    string newName = ConsoleHelpers.GetData("Inserire nuovo nome", owner.Nome);
                    if (!string.IsNullOrEmpty(newName))
                        owner.Nome = newName;

                    string newCognome = ConsoleHelpers.GetData("Inserire nuovo cognome", owner.Cognome);
                    if (!string.IsNullOrEmpty(newCognome))
                        owner.Cognome = newCognome;

                    var body = new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json");
                    response = _client.PutAsync("api/owner", body).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ConsoleHelpers.SuccessMessage("Aggiornamento riuscito");
                    }
                    else
                    {
                        content = response.Content.ReadAsStringAsync().Result;
                        ConsoleHelpers.ErrorMessage("Errore durante aggiornamento: " + content);
                    }
                }

            }


        }

        internal void ListAllUnitsByType()
        {
            throw new NotImplementedException();
        }

        internal void ListAllUnitsByOwner()
        {
            throw new NotImplementedException();
        }

        internal void ListAllOwners()
        {
            ConsoleHelpers.InfoMessage("=== Owners List ===");
            var response = _client.GetAsync("api/owner").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var owners = JsonConvert.DeserializeObject<List<Owner>>(content);
                ConsoleHelpers.PrintTable(owners, ConsoleUtils.ownerColumns, "Elenco Proprietari");
            }
        }
    }
}
