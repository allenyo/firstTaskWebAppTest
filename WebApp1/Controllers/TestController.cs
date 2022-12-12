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
        [HttpPost]
        public IActionResult ConverterTest(ConvertRequestModel requestModel)
        {
                var value = requestModel.Value.ToString();
                value ??= string.Empty;

                var response = ConvertTo(value, requestModel.InType, requestModel.OutType);

                return response;
 
        }

        private IActionResult ConvertTo<T>(T Value, Types type, Types OutType)
        {
           
            if (Value == null)
                return Ok(new ErrorModel { Code = 98, Error = "ValueNull", Message = "Value is null." });

            var value = Value.ToString();

            if (value == null)
                return Ok(new ErrorModel { Code = 98, Error = "IncorrectValue", Message = "Incorrect Value." });

            try
            {
                switch (type)
                {
                    case Types.String:
                        var res = Convert(value.ToString(), OutType);
                        return Ok(res);
                    case Types.Int:
                        res = Convert(int.Parse(value), OutType);
                        return Ok(res);
                    case Types.Long:
                        res = Convert(long.Parse(value), OutType);
                        return Ok(res);
                    case Types.Ulong:
                        res = Convert(ulong.Parse(value), OutType);
                        return Ok(res);
                    case Types.Float:
                        res = Convert(float.Parse(value), OutType);
                        return Ok(res);
                    case Types.Double:
                        res = Convert(double.Parse(value), OutType);
                        return Ok(res);
                    case Types.Bool:
                        res = Convert(bool.Parse(value), OutType);
                        return Ok(res);
                    case Types.Object:
                        res = Convert((object)value, OutType);
                        return Ok(res);
                    case Types.Byte:
                        res = Convert(byte.Parse(value), OutType);
                        return Ok(res);
                    case Types.Char:
                        res = Convert(char.Parse(value), OutType);
                        return Ok(res);
                    case Types.ArrayList:
                        res = Convert(new ArrayList(value.ToArray()), OutType);
                        return Ok(res);
                    case Types.Decimal:
                        res = Convert(decimal.Parse(value), OutType);
                        return Ok(res);
                    case Types.Sbyte:
                        res = Convert(sbyte.Parse(value), OutType);
                        return Ok(res);
                    case Types.Uint:
                        res = Convert(uint.Parse(value), OutType);
                        return Ok(res);
                    case Types.List:
                        res = Convert(value.ToList(), OutType);
                        return Ok(res);
                    case Types.Dictionary:
                        var dictionary = value
                        .Split(';', ',')
                        .Select(part => part.Split('='))
                        .Where(part => part.Length == 2)
                        .ToDictionary(sp => sp[0], sp => sp[1]);
                        res = Convert(dictionary, OutType);
                        return Ok(res);
                    case Types.Short:
                        res = Convert(short.Parse(value), OutType);
                        return Ok(res);
                    case Types.Ushort:
                        res = Convert(ushort.Parse(value), OutType);
                        return Ok(res);
                    case Types.DateTime:
                        res = Convert(DateTime.Parse(value), OutType);
                        return Ok(res);
                    default:
                        var error = new ErrorModel { Code = 99, Error = "IncorrectInType", Message = "Incorrect in type" };
                        return Ok(error.ToString());
                }     
            } catch(Exception ex)
            {
                var error = new ErrorModel { Code = 95, Error = ex.Source + "Exception", Message = ex.ToString()};
                return Ok(error.ToString());

            }
        }
      
        private static string Convert<T>(T value, Types OutType)
        {
            if (value == null)
              return  new ErrorModel { Code = 98, Error = "ValueNull", Message = "Value is null." }.ToString();

           var response = $"Converted {value.GetType().Name} to {OutType}\n" +
           $"Value - {value}\n" +
           $"Result - ";

            switch (OutType)
            {
                case Types.Bool: response += value.ToBoolean(); break;
                case Types.Byte: response += value.ToByte(); break;
                case Types.Char: response += value.ToChar(); break;
                case Types.Double: response += value.ToDouble(); break;
                case Types.Float: response += value.ToSingle(); break;
                case Types.Ushort: response += value.ToUInt16(); break;
                case Types.Ulong: response += value.ToUInt64(); break;
                case Types.Uint: response += value.ToUInt32(); break;
                case Types.Long: response += value.ToInt64(); break;
                case Types.Int: response += value.ToInt32(); break;
                case Types.Decimal: response += value.ToDecimal(); break;
                case Types.String: response += value.ToString<T>(); break;
                case Types.DateTime: response += value.ToDateTime(); break;
                case Types.Sbyte: response += value.ToSByte(); break;
                case Types.Short: response += value.ToInt16(); break;
                default: return new ErrorModel { Code = 99, Error = "IncorrectOutType", Message = "Incorrect out type" }.ToString(); break;
            }

            Console.WriteLine(response);
            return response;      
        }
 
    }
}
