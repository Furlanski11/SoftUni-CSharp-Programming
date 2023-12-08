using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private int boothid;
        private double currentBill;
        private double turnover;
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();

            currentBill = 0;
            turnover = 0;
        }
        public int BoothId { get => boothid; private set => boothid = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public DelicacyRepository delicacies;
       
        public CocktailRepository cocktails;
        public IRepository<IDelicacy> DelicacyMenu => delicacies;

        public IRepository<ICocktail> CocktailMenu => cocktails;

        public double CurrentBill => currentBill;

        public double Turnover => turnover;

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (IsReserved == false)
            {
                IsReserved = true;
            }
            else
            {
                IsReserved = false;
            }
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine($"-Coctail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
