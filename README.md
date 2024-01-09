# HowUseTook
学习怎么去使用CommunityToolkit工具包

可观测对象.ObservableValidator

官方文档：[ObservableValidator - Community Toolkits for .NET | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/observablevalidator)



### 工作原理

ObservableValidator是除了继承INotifyPropertyChanged之外，还继承了INotifyDataErrorInfo

它可用作需要支持属性更改通知和属性验证的各种对象的起点。

### 基本用法

在属性下添加特征Required

```c#
[ObservableProperty]
[Required]
[EmailAddress]

string? email;
```

## 自带校验属性

需要验证邮箱地址是否正确，添加EmailAddress特征

校验长度使用MinLength和MaxLength特征

校验数字范围，使用Range特征

```c#
        [ObservableProperty]
        [Required(ErrorMessage ="用户名不能为空")]
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
               SetProperty(ref age, value);
            }

        }
```

### 校验触发方法

1，后端触发方法有

- 使用ValidateProperty(）

	```c#
	[Required]
	        [Range(20, 120)]
	        public int? Age
	        {
	            get => age;
	            set
	            {
	                //方法1
	                //ValidateProperty(value);//后端触发校验
	            }
	
	        }
	```

- 使用SetProperty的重构方法

```c#
        [Required]
        [Range(20, 120)]
        public int? Age
        {
            get => age;
            set
            {
                SetProperty(ref age, value, true);
            }

        }
```

### 多语言错误信息制定

新建两个.resx文件

Lang.resx

Lang.zh-CN.resx

![20587ea682cbf5dd617c95d93fa1db13.png](F:\GitWorkerCode\HowUseTook\iamges\9bd96023b3b94f40ab1637eaf9e74f57.png)

填写相应信息

- 在特效处填写

	```c#
	 		[ObservableProperty]
	        [Required(ErrorMessageResourceName = "Name_Required",ErrorMessageResourceType =typeof(Lang))]
	        [MinLength(2)]
	        [MaxLength(7)]
	        string? name;
	```

	ErrorMessageResourceName：表示对应的名词

	ErrorMessageResourceType：表示对应的来源

- 切换

	```c#
	        public App()
	        {
	                Thread.CurrentThread.CurrentCulture=new CultureInfo("zh-CN");
	                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
	
	        }
	
	```
