using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        IRepository<IBooth> booths;
        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth currentBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail;
            if (cocktailTypeName == typeof(Hibernation).Name)
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == typeof(MulledWine).Name)
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (size != "Small" || size != "Middle" || size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (currentBooth.CocktailMenu.Models.Contains(cocktail))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktail.Name);
            }
            else
            {
                currentBooth.CocktailMenu.AddModel(cocktail);
                return String.Format(OutputMessages.NewCocktailAdded, size, cocktail.Name, cocktail.GetType().Name);
            }

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth currentBooth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (currentBooth.DelicacyMenu.Models.Contains(delicacy))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacy.Name);
            }
            else
            {
                currentBooth.DelicacyMenu.AddModel(delicacy);
                return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");

            booth.Charge();
            booth.ChangeStatus();

            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = this.booths.Models
                 .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                 .OrderBy(b => b.Capacity)
                 .ThenByDescending(b => b.BoothId)
                 .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] orderArray = order.Split('/');

            bool isCocktail = false;

            string itemTypeName = orderArray[0];

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            string itemName = orderArray[1];

            if (!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            int pieces = int.Parse(orderArray[2]);



            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                isCocktail = true;
            }

            if (isCocktail)
            {
                string size = orderArray[3];

                ICocktail desiredCocktail = booth
                    .CocktailMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName && m.Size == size);

                if (desiredCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(desiredCocktail.Price * pieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
            }
            else
            {
                IDelicacy desiredDelicacy = booth
                .DelicacyMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemName);
                }

                booth.UpdateCurrentBill(desiredDelicacy.Price * pieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
            }
        }

    }
}

