# ReCapProject

Autofac :IOS yapılandırmasını Autofac”e çevireceğiz. 
NEYI NEDEN YAPIYORUZ:	WebAPI  projesi Startup içinde sevices.AddControllers(); kısmında yapabiliriz ancak yeni bir API eklediğimizde  bu işlemi bir daha yapmak zorunda kalırız. Bu yapılandırmayı daha geriye taşıyabiliriz. Onun yerine AUTOFAC yapılandırması yapabiliriz

Step-78		KURULUM:

Business sağ tıkla “Manage nuget Packages” kısmini açalım
Browse kısmında Autofac yazarak arayalım Son versiyonu (V 6.1..0) kuralım. Sikinti olursa 3.11.1i kurabiliriz

Step-79
Browse kısmında autofac.EXTRAS yazarak arayalım
Autofac.EXTRAS.DynamicProxy adli eklentiyi kuralım (Son versiyon)

Step-80
BUSINESS içinde DependencyResolvers adlı klasör oluşturalım. 
Altına Autofac adli bir klasör oluşturalım Burada IPRODUCTDAL’in karşılığını tanımlayacağız
WebAPI   startup içinde içinde yaptığımız ayarları Businessa taşıyacağız

Step-81
Autofac içinde AutofacBusinessModule adli class ekle (aynisi kendi core katmanimizda da yapacagiz)

Public yapalım Module ‘e inherit yapalım. ampulden “using Autofac” seçelim

Override yazıp space tuşuna basarsak seçenekler çıkar
“Load” adli metodu seçelim

WebAPI startup da services.addsingleton<…> olarak yazdığımız kodun karşılığını yazacağız

ProductManager ve IProductService ampulde using komut satirini ekle.
Aynisini EfProductDal e IProductDal içinde yap.
(örneğin bir web sayfasında 100 kişi  için ayni eylemi istediğinde ayrı ayrı çalıştırmak yerine tek bunu kullanıyor)
Bunu diğerleri içinde yapalım
 




STEP-82

WebAPI startup kısmındaki services.AddSingleton………. diye başlayan satırları iptal edelim. Çalışmayacaktır

Burada kendi IOS yapılandırması yerine kendi tanımladığımız yapılandırmayı kullanmasını sağlayacağız

STEP-83
WebAPI ‘nin Program kısmını açalım

Service Provider olarak “AutofacServiceProviderFactory” tanıtacağız ve ampulden “Install packagesAutofacExtensionsDependencyInjection’’” seklinde 2. Seçenekten “Find and Install Latest Version” seçeceğiz.
Referansı tutan bir yapı oluştu

Configure Container kısmını yapacağız. Yazdigimiz AutofacBusineessModule yapilandirmada kullanilacagini belirtecegiz 
ContainerBuilder icin Ampulden Using komutu satirini çözelim
AutofacBusinessModule icin de Using komut satirini çözelim

Şimdi WebAPI programı tekrar çalıştıralım ve Postman”de çalıştığını görelim. Çalıştı
