using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Order
{
    public class UpdateOrderRequestDto
    {
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [RegularExpression(@"^[a-zA-ZĄąČčĘęĖėĮįŠšŲųŪūŽž\s]+$")]
        [MaxLength(35, ErrorMessage = "Vardas per ilgas")]
        public string CustomerName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [RegularExpression(@"^[a-zA-ZĄąČčĘęĖėĮįŠšŲųŪūŽž\s]+$")]
        [MaxLength(35, ErrorMessage = "Pavardė per ilga")]
        public string CustomerSurname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [RegularExpression(@"^\d{8}$")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [EmailAddress(ErrorMessage = "Neteisingas el. paštas")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [RegularExpression(@"^[a-zA-Z0-9ĄČĘĖĮŠŲŪŽąčęėįšųūž\s.,]+$")]
        [MaxLength(150, ErrorMessage ="Per ilgas adresas")]
        public string Adress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [RegularExpression(@"^[a-zA-ZĄąČčĘęĖėĮįŠšŲųŪūŽž\s]+$")]
        [MaxLength(100, ErrorMessage ="Per ilgas miesto pavadinimas")]
        public string City { get; set; } = string.Empty;
        public DateTime ReservationTime { get; set; }
    }
}