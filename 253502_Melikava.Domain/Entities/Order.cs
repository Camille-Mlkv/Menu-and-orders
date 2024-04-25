

namespace _253502_Melikava.Domain.Entities
{
    public class Order:Entity
    {
        public Order() { }
        public Order(string clientName, int preparationTime, bool birthdayGift, string sauce)
        {
            ClientName = clientName;
            PreparationTime = preparationTime;
            BirthdayGift = birthdayGift;
            Sauce = sauce;
        }
        public string? ClientName { get;  set; }
        public int PreparationTime { get;  set; }
        public bool BirthdayGift { get;  set; }
        public string? Sauce {  get; set; }
        public int? MenuPositionId { get;  set; }

        public void AddToMenuPosition(int menuPositionId)
        {
            if (menuPositionId < 0) return;
            MenuPositionId = menuPositionId;
        }

        public void LeaveMenuPosition()
        {
            MenuPositionId = 0;
        }

        public void ModifyPreparationTime(int preparationTime)
        {
            if(preparationTime < 0 || preparationTime>120) return;
            PreparationTime = preparationTime;
        }

    }
}
