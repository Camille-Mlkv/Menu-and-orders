
namespace _253502_Melikava.Domain.Entities
{
    public class Order:Entity
    {
        private Order() { }
        public Order(string clientName, double preparationTime, bool birthdayGift, string sauce)
        {
            ClientName = clientName;
            PreparationTime = preparationTime;
            BirthdayGift = birthdayGift;
            Sauce = sauce;
        }
        public string? ClientName { get; private set; }
        public double PreparationTime { get; private set; }
        public bool BirthdayGift { get; private set; }
        public string? Sauce {  get; set; }
        public int? MenuPositionId { get; private set; }

        public void AddToMenuPosition(int menuPositionId)
        {
            if (menuPositionId < 0) return;
            MenuPositionId = menuPositionId;
        }

        public void LeaveMenuPosition()
        {
            MenuPositionId = 0;
        }

        public void ModifyPreparationTime(double preparationTime)
        {
            if(preparationTime < 0 || preparationTime>120) return;
            PreparationTime = preparationTime;
        }

    }
}
