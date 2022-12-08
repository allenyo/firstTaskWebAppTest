using api1Domain.Enums;
using api1Domain.Models;
using api1Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly Dictionary<string, Type> _types = new(TypeConverter.GetTypes());


        [HttpPost]
        public IActionResult ConverterTest(Types type, object Value)
        {
            var value = Value.ToString();
            value ??= string.Empty;

            var response = ConvertToBool(type,value);      

            return response;
    
        }

        private IActionResult ConvertToBool(Types type, string value)
        {
            switch (type)
            {
                case Types.String:
                    var res = ConvertToBool(value, typeof(string));
                    return Ok(res);
                case Types.Int:
                    res = ConvertToBool(int.Parse(value), typeof(int));
                    return Ok(res);
                case Types.Long:
                    res = ConvertToBool(long.Parse(value), typeof(long));
                    return Ok(res);
                case Types.Ulong:
                    res = ConvertToBool(ulong.Parse(value), typeof(ulong));
                    return Ok(res);
                case Types.Float:
                    res = ConvertToBool(float.Parse(value), typeof(float));
                    return Ok(res);
                case Types.Double:
                    res = ConvertToBool(double.Parse(value), typeof(double));
                    return Ok(res);
                case Types.Bool:
                    res = ConvertToBool(bool.Parse(value), typeof(bool));
                    return Ok(res);
                case Types.Object:
                    res = ConvertToBool((object)value, typeof(object));
                    return Ok(res);
                case Types.Byte:
                    res = ConvertToBool(byte.Parse(value), typeof(byte));
                    return Ok(res);
                case Types.Char:
                    res = ConvertToBool(char.Parse(value), typeof(char));
                    return Ok(res);
                case Types.ArrayList:
                    res = ConvertToBool(new ArrayList(value.ToArray()), typeof(ArrayList));
                    return Ok(res);
                case Types.Decimal:
                    res = ConvertToBool(decimal.Parse(value), typeof(decimal));
                    return Ok(res);
                case Types.Sbyte:
                    res = ConvertToBool(sbyte.Parse(value), typeof(sbyte));
                    return Ok(res);
                case Types.Uint:
                    res = ConvertToBool(uint.Parse(value), typeof(uint));
                    return Ok(res);
                case Types.List:
                    res = ConvertToBool(value.ToList(), typeof(List<>));
                    return Ok(res);
                case Types.Dictionary:
                    var dictionary = value
                    .Split(';',',')
                    .Select(part => part.Split('='))
                    .Where(part => part.Length == 2)
                    .ToDictionary(sp => sp[0], sp => sp[1]);
                    res = ConvertToBool(dictionary, typeof(Dictionary<,>));
                    return Ok(res);
                case Types.Short:
                    res = ConvertToBool(short.Parse(value), typeof(short));
                    return Ok(res);
                case Types.Ushort:
                    res = ConvertToBool(ushort.Parse(value), typeof(ushort));
                    return Ok(res);
                default:
                    var error = new ErrorModel { Code = 99, Error = "IncorrectType", Message = "Type not selected" };
                    return Ok(error.ToString());
    
            }
        }

        private static string ConvertToBool<T>(T value, Type type)
        {
            if (value != null)
            {
                try
                {
                    var res = value.ToBoolean();
                    var s = $"Converted {type} to {res.GetType()}\n" +
                        $"Value - {value}\n" +
                        $"Result - {res}";
                    Console.WriteLine(s);

                    return s;

                } catch (Exception ex)
                {
                    var error = new ErrorModel { Code = 98, Error = $"{ex.Source} ", Message = $"{ex.Message} \n" +
                        $"Cant convert from {type.Name} (value = {value}) To {typeof(bool)} " };

                    return error.ToString();

                }


            }
            else
            {
                var error = new ErrorModel { Code = 98, Error = "ValueNull", Message = "Value is null." };

               return error.ToString();
            }

        }
 
    }
}
