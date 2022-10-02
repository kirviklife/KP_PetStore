using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KP_APP.Models
{
    public class departments
    {
        [Key]
        //Первичный ключ
        public int id_dep { get; set; }
        //Вывод ошибки
        [Required(ErrorMessage = "Введите наименование отдела")]
        //Ограничения ввода
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 100 и не менее 1 символов")]
        //Отображение на странице
        [Display(Name = "Наименование отдела", Description = "desc")]
        //Регулярное выражение
        [RegularExpression(@"^([а-яА-Я .&'-]+)$", ErrorMessage = "Поле наименования должно содержать только русские буквы")]
        public string dep_name { get; set; }
        public departments()
        {
            this.sost_departments = new HashSet<sost_departments>();
        }
        public ICollection<sost_departments> sost_departments { get; set; }
    }

    public class positions
    {
        [Key]
        //Первичный ключ
        public int id_pos { get; set; }
        //Вывод ошибки
        [Required(ErrorMessage = "Введите наименование должности")]
        //Ограничения ввода
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 100 и не менее 1 символов")]
        //Отображение на странице
        [Display(Name = "Наименование должности", Description = "desc")]
        //Регулярное выражение
        [RegularExpression(@"^([а-яА-Я .&'-]+)$", ErrorMessage = "Поле наименования должно содержать только русские буквы")]
        public string pos_name { get; set; }
        public positions()
        {
            this.sost_departments = new HashSet<sost_departments>();
        }
        public virtual ICollection<sost_departments> sost_departments { get; set; }
    }

    public class sost_departments
    {
        [Key]
        //Первичный ключ
        public int id_sost_dep { get; set; }
        [ForeignKey("departments")]
        [Display(Name = "Наименование отдела", Description = "desc")]
        public int id_dep { get; set; }
        [ForeignKey("positions")]
        [Display(Name = "Наименование должности", Description = "desc")]
        public int id_pos { get; set; }
        public virtual positions positions { get; set; }
        public virtual departments departments { get; set; }
    }

    public class status_zakazis
    {
        [Key]
        //Первичный ключ
        public int id_status { get; set; }
        //Вывод ошибки
        [Required(ErrorMessage = "Введите наименование статуса")]
        //Ограничения ввода
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 100 и не менее 1 символов")]
        //Отображение на странице
        [Display(Name = "Наименование статуса заказа", Description = "desc")]
        public string status_name { get; set; }
    }

    public class accounts
    {
        [Key]
        //Первичный ключ
        [Display(Name = "Логин пользователя", Description = "desc")]
        [Required(ErrorMessage = "Введите логин")]
        //Ограничения ввода
        [StringLength(80, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 80 и не менее 1 символов")]
        public string login { get; set; }
        [Display(Name = "Фамилия пользователя", Description = "desc")]
        [Required(ErrorMessage = "Укажите фамилию")]
        //Ограничения ввода
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 50 и не менее 1 символов")]
        public string fam { get; set; }
        [Display(Name = "Имя пользователя", Description = "desc")]
        [Required(ErrorMessage = "Укажите имя")]
        //Ограничения ввода
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 50 и не менее 1 символов")]
        public string im { get; set; }
        [Display(Name = "Отчество пользователя", Description = "desc")]
        //Ограничения ввода
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 50 и не менее 1 символов")]
        public string? otch { get; set; }
        [Display(Name = "Пароль пользователя", Description = "desc")]
        public string passwordhash { get; set; }
        [Display(Name = "Номер телефона", Description = "desc")]
        [Required(ErrorMessage = "Укажите номер телефона")]
        public string numphone { get; set; }
        [Display(Name = "Эл. почта пользователя", Description = "desc")]
        [Required(ErrorMessage = "Укажите электронную почту")]
        public string email { get; set; }
        [Display(Name = "Является сотрудником", Description = "desc")]
        public bool is_sotr { get; set; }

    }

    public class tov_kategories
    {
        [Key]
        //Первичный ключ
        public int id_kategor { get; set; }
        //Вывод ошибки
        [Required(ErrorMessage = "Укажите наименование категории товара")]
        //Ограничения ввода
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 100 и не менее 1 символов")]
        //Отображение на странице
        [Display(Name = "Наименование категории товара", Description = "desc")]
        public string kategor_name { get; set; }
        [ForeignKey("tov_kategories")]
        [Display(Name = "Категория", Description = "desc")]
        public int? kat_glav_id { get; set; }
        [ForeignKey("kat_glav_id")]
        public tov_kategories tov_kategories1 { get; set; }
        public tov_kategories()
        {
            this.sootv_kategor_parameters = new HashSet<sootv_kategor_parameters>();
        }
        public virtual ICollection<sootv_kategor_parameters> sootv_kategor_parameters { get; set; }
    }

    public class parameters
    {
        [Key]
        //Первичный ключ
        public int id_param { get; set; }
        //Вывод ошибки
        [Required(ErrorMessage = "Укажите наименование параметра для описания товара")]
        //Ограничения ввода
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна содержать не более 100 и не менее 1 символов")]
        //Отображение на странице
        [Display(Name = "Наименование параметра для описания товара", Description = "desc")]
        public string param_name { get; set; }
        public parameters()
        {
            this.sootv_kategor_parameters = new HashSet<sootv_kategor_parameters>();
        }
        public virtual ICollection<sootv_kategor_parameters> sootv_kategor_parameters { get; set; }
    }

    public class sootv_kategor_parameters
    {
        [Key]
        //Первичный ключ
        public int id_sootv_par { get; set; }
        [ForeignKey("tov_kategories")]
        [Display(Name = "Категория", Description = "desc")]
        public int? id_kategor { get; set; }
        public tov_kategories tov_kategories { get; set; }
        [ForeignKey("parameters")]
        [Display(Name = "Параметр", Description = "desc")]
        public int? id_param { get; set; }
        public parameters parameters { get; set; }
    }



    //Если таблицы располагаются в разных схемах, можно указать перед классом
    // имя таблицы и имя схемы
    //[Table("departments", Schema = "test")]

}
