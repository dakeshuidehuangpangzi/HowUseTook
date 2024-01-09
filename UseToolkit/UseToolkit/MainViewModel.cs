using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UseToolkit.Properties;

namespace UseToolkit
{
    partial class MainViewModel: ObservableValidator
    {
        [ObservableProperty]
        //[Required(ErrorMessage ="用户名不能为空")]
        [Required(ErrorMessageResourceName = "Name_Required",ErrorMessageResourceType =typeof(Lang))]
        [MinLength(2)]
        [MaxLength(7)]
        string? name;

        [ObservableProperty]
        [Required]
        [EmailAddress]
        string? email;

        private int? age;

        [Required]
        [Range(20, 120)]
        public int? Age
        {
            get => age;
            set
            {
                //SetProperty(ref age, value, true);

                //方法2：离开就自动触发
                SetProperty(ref age, value, true);

                //方法1
                //ValidateProperty(value);//后端触发校验
            }

        }
        [ObservableProperty]
        string? errmessage;
        [RelayCommand]
        void Reqister()
        {
             ValidateAllProperties();//触发所有的校验
            if (HasErrors)
            {
                Errmessage = string.Join(Environment.NewLine, GetErrors());
                return;
            }
            Errmessage = "";
            MessageBox.Show($"OK");
        }
    }
}
