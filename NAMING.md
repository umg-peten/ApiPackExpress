# Estandar de codigo y nombramiento C# 

| Nombre del objeto         | Notacion   | Longitud | Plural | Prefijo | Sufijo | Abreviatura | Caracteres admitidos  | Guiones bajos |
|:--------------------------|:-----------|-------:|:-------|:-------|:-------|:-------------|:-------------------|:------------|
| Namespace            | PascalCase |    128 | Si    | Si    | No     | No           | [A-z][0-9]         | No          |
| Clase               | PascalCase |    128 | No     | No     | Si    | No           | [A-z][0-9]         | No          |
| Constructor          | PascalCase |    128 | No     | No     | Si    | No           | [A-z][0-9]         | No          |
| Metodo               | PascalCase |    128 | Si    | No     | No     | No           | [A-z][0-9]         | No          |
| Argumentos del metodo          | camelCase  |    128 | Si    | No     | No     | Si          | [A-z][0-9]         | No          |
| Variables locales           | camelCase  |     50 | Si    | No     | No     | Si          | [A-z][0-9]         | No          |
| Constantes            | PascalCase |     50 | No     | No     | No     | No           | [A-z][0-9]         | No          |
| Campos                | camelCase  |     50 | Si    | No     | No     | Si          | [A-z][0-9]         | Si         |
| Propiedades           | PascalCase |     50 | Si    | No     | No     | Si          | [A-z][0-9]         | No          |
| Delegados             | PascalCase |    128 | No     | No     | Si    | Si          | [A-z]              | No          |
| Enumeradores            | PascalCase |    128 | Si    | No     | No     | No           | [A-z]              | No          |

#### 1. Usa PascalCase para las clases y los metodos:

```csharp
public class ClientActivity
{
  public void ClearStatistics()
  {
    //...
  }
  public void CalculateStatistics()
  {
    //...
  }
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 2. Usa camelCase para los argumentos (parametros) y variables locales:

```csharp
public class UserLog
{
  public void Add(LogEvent logEvent)
  {
    int itemCount = logEvent.Items.Count;
    // ...
  }
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 3. No uses notacion hungara para los tipos 

```csharp
// Correcto
int counter;
string name;    
// Evitar
int iCounter;
string strName;
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer. y Visual Studio makes hace facil de determinar tipos (via tooltips).***

#### 4. No usar MAYUSCULAS para ninguna variable:

```csharp
// Correcto
public const string ShippingType = "DropShip";
// Evitar
public const string SHIPPINGTYPE = "DropShip";
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 5. Usa nombres de variables utiles. El siguiente ejemplo usa seattleCustomers para los clientes localizados en Seattle:

```csharp
var seattleCustomers = from customer in customers
  where customer.City == "Seattle" 
  select customer.Name;
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 6. Evita usar abreviaciones, con excepcion a las abreviaturas de nombres comunes: Id, Xml, Ftp, Uri.

```csharp    
// Correcto
UserGroup userGroup;
Assignment employeeAssignment;     
// Evitar
UserGroup usrGrp;
Assignment empAssignment; 
// Excepciones
CustomerId customerId;
XmlDocument xmlDocument;
FtpHelper ftpHelper;
UriPart uriPart;
```

***Por que?: Es consistente con el framework de Microsoft .NET y previene abreviaciones inconsistentes.***


#### 7. Puedes usar PascalCase o camelCase (Dependiendo del tipo de identificador) para abreviaciones de 3 caracteres o mas.:

```csharp  
HtmlHelper htmlHelper;
FtpTransfer ftpTransfer, fastFtpTransfer;
UIControl uiControl, nextUIControl;
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 8. No uses guiones bajos en variables (identificadores). Excepcion: campos privados:

```csharp 
// Correcto
public DateTime clientAppointment;
public TimeSpan timeLeft;    
// Evitar
public DateTime client_Appointment;
public TimeSpan time_Left; 
// Excepcion (Campo de la clase)
private DateTime _registrationDate;
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 9. Usa los tipos predefinidos (los alias de C#) como `int`, `float`, `string` para locales, parametros y declaraciones de miembros. Usa los nombres del frameowrk .NET como `Int32`, `Single`, `String` cuando accedas a los miembros estaticos `Int32.TryParse` or `String.Join`.

```csharp
// Correcto
string firstName;
int lastIndex;
bool isSaved;
string commaSeparatedNames = String.Join(", ", names);
int index = Int32.Parse(input);
// Evitar
String firstName;
Int32 lastIndex;
Boolean isSaved;
string commaSeparatedNames = string.Join(", ", names);
int index = int.Parse(input);
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 10. Usa var para variables locales implicitas. Excepciones: tipos primitivos  (int, string, double, etc). 

```csharp 
var stream = File.Create(path);
var customers = new Dictionary();
// Excepciones
int index = 100;
string timeSheet;
bool isCompleted;
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 11. Usa un sustantivo para el nombramiento de las clases. 

```csharp 
public class Employee
{
}
public class BusinessLocation
{
}
public class DocumentCollection
{
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 12. Usa el prefijo I para nombras las interfaces.

```csharp     
public interface IShape
{
}
public interface IShapeCollection
{
}
public interface IGroupable
{
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 13. Organiza los namespaces con estructuras definidas: 

```csharp 
// Ejemplos
namespace Company.Technology.Feature.Subnamespace
{
}
namespace Company.Product.Module.SubModule
{
}
namespace Product.Module.Component
{
}
namespace Product.Layer.Module.Group
{
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 45. Alinea verticalmente las llaves

```csharp 
// Correcto
class Program
{
  static void Main(string[] args)
  {
    //...
  }
}
```

***Por que?: Microsoft tiene un estandar diferente, pero esto aumenta la legibilidad.***

#### 15. Declara las variables miembro hasta arriba, y las estaticas al inicio.

```csharp 
// Correcto
public class Account
{
  public static string BankName;
  public static decimal Reserves;      
  public string Number { get; set; }
  public DateTime DateOpened { get; set; }
  public DateTime DateClosed { get; set; }
  public decimal Balance { get; set; }     
  // Constructor
  public Account()
  {
    // ...
  }
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 16. Usa nombres singulares para enumeradores. Excepcion: enumeradores de bits.

```csharp 
// Correcto
public enum Color
{
  Red,
  Green,
  Blue,
  Yellow,
  Magenta,
  Cyan
} 
// Excepcion
[Flags]
public enum Dockings
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 17. No especifiques directamente el tipo o los valores de un enumerador(except bit fields):

```csharp 
// Esto no
public enum Direction : long
{
  North = 1,
  East = 2,
  South = 3,
  West = 4
} 
// Correcto
public enum Direction
{
  North,
  East,
  South,
  West
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 18.No uses el prefijo Enum :

```csharp     
// Esto no
public enum CoinEnum
{
  Penny,
  Nickel,
  Dime,
  Quarter,
  Dollar
} 
// Correcto
public enum Coin
{
  Penny,
  Nickel,
  Dime,
  Quarter,
  Dollar
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 19. No uses el sufijo Flag o Flags en enumeradores:

```csharp 
// Esto no
[Flags]
public enum DockingsFlags
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
// Correcto
[Flags]
public enum Dockings
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
```

***Por que?: Es consistente con el framework de Microsoft .NET.***

#### 20. Usa el sufijo EventArgs en la creacion de nuevas clases que conforman la informacion de un evento:

```csharp 
// Correcto
public class BarcodeReadEventArgs : System.EventArgs
{
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 21. Nombra los EventHandlers con el sufijo "EventHandler":

```csharp 
public delegate void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e);
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 22. No utilices argumentos (parametros) que solo difieran en la mayuscula:

```csharp 
// Evitar
private void MyFunction(string name, string Name)
{
  //...
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 23. Usa dos argumentos en un EventHandler. El sender representa el objeto que hizo cast del Evento. El sender siempre es de tipo objeto.

```csharp
public void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e)
{
  //...
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 24. Usa el sufijo Exception en la creacion de nuevas clases que conforman la informacion de una excepcion:

```csharp 
// Correcto
public class BarcodeReadException : System.Exception
{
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 25. Usa el prefijo Is, Any, Have en booleanos:

```csharp 
// Correcto
public static bool IsNullOrEmpty(string value) {
    return (value == null || value.Length == 0);
}
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

#### 26. Usa argumentos nombrados al llamar un metodo:

```csharp
// Metodo
public void DoSomething(string foo, int bar) 
{
...
}

// Evitar
DoSomething("someString", 1);
// Correcto
DoSomething(foo: "someString", bar: 1);
```

***Por que?: Es consistente con el framework de Microsoft .NET y es facil de leer.***

## Referencias oficiales

1. [MSDN General Naming Conventions](http://msdn.microsoft.com/en-us/library/ms229045(v=vs.110).aspx)
2. [DoFactory C# Coding Standards and Naming Conventions](http://www.dofactory.com/reference/csharp-coding-standards) 
3. [MSDN Naming Guidelines](http://msdn.microsoft.com/en-us/library/xzf533w0%28v=vs.71%29.aspx)
4. [MSDN Framework Design Guidelines](http://msdn.microsoft.com/en-us/library/ms229042.aspx)
