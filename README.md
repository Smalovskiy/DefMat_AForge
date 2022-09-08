# DefMat_V2.0
Приложение цифрового определения растяжения матераиала.
Структура проекта:
Формы:
-Form1.cs- Главная форма приложения, форма для настройки проекта, выбора устройства, подсчёта результатов.
  В данной форме реализован почти весь функционал, исключение:
  1)Кнопка Файл - кнопка потеряла свою надобность, поскольку все данные идут в базу данных
  2)Кнопка Справка - поскольку проект сырой, справку писать не актуально.
  3)Кнопка Graphs - необходимо разработать.
  4)TextBox Высота - баг с корректностью подсчётов, при динамическом изменении.
-ScreenForm.cs - Форма для создания скриншотов, возможность сохранить в нужный каталог на пк. 
  Не реализовано, либо подлежит удалению:
  1)Редактирование (Edit) 
-DBMaterialForm.cs - Форма для просмотра материала и его свойств, позволяет добавлять/редактировать/удалять материал, 
  а также экспортировать в Excel, не реализована:
  1)Связь между материалом, его свойствами с измерениями контроллера.
-DBExtensionsForm.cs - Форма с данными относительного удлиннения материала,позволяет просматривать/экспортировать/удалять данные.
-DBResultsForm.cs -Форма с результатами по материалу после эксперимента,позволяет просматривать/экспортировать/удалять данные, 
  не реализовано:
  1)Получение данных с контроллера и форму подсчёта.
-AddMaterialForm - Форма для добавления материала, вспомогательная форма для DBMaterialForm.cs.
В проект интегрирован entity framework version 6.0.0.0
Models - в данной папке содержаться классы-сущности для удобного связывания и вывода данных в бд.
Migrations - автоматически сконфигурированная папка после миграции бд.
В качестве субд была выбра microsoft sql server management studio.
Cтрока подключения App.config:
<connectionStrings>
  <add name="DefMatConnection" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DefMatConnection;Integrated Security=True;"
   providerName="System.Data.SqlClient" />
  <add name="DefMat_V2._0.Properties.Settings.DefMatConnectionConnectionString"
   connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DefMatConnection;Integrated Security=True"
   providerName="System.Data.SqlClient" />
 </connectionStrings>
