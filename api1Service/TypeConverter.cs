using System.Collections;

namespace api1Service
{
    public static class TypeConverter
    {
        private static readonly Dictionary<string, Type> _types = new Dictionary<string, Type>(SetTypes());

        public static IDictionary<string, Type> GetTypes()
        {
            return _types;
        }

        private static IDictionary<string, Type> SetTypes()
        {
            return new Dictionary<string, Type>
            {
                ["string"] = typeof(string),
                ["int16"] = typeof(short),
                ["int32"] = typeof(int),
                ["int64"] = typeof(long),
                ["uint16"] = typeof(ushort),
                ["uint32"] = typeof(uint),
                ["uint64"] = typeof(ulong),
                ["single"] = typeof(float),
                ["datetime"] = typeof(DateTime),
                ["double"] = typeof(double),
                ["byte"] = typeof(byte),
                ["sbyte"] = typeof(sbyte),
                ["boolean"] = typeof(bool),
                ["decimal"] = typeof(decimal),
                ["char"] = typeof(char),
                ["object"] = typeof(object),
                ["arraylist"] = typeof(ArrayList),
                ["list"] = typeof(List<>),
                ["dictionary"] = typeof(Dictionary<,>)
            };
        }

        public static bool ToBoolean<T>(this T Value)
        {
            if (Value == null)
                throw new ArgumentNullException(nameof(Value));

            var typeName = typeof(T).Name.ToLower();

            _ = _types.TryGetValue(typeName, out var valueType);

            if (valueType == null)
                throw new ArgumentException("Wrong type", nameof(Value));

            if (valueType.IsValueType)
            {
                if (valueType == typeof(bool))
                {
                    return Value switch
                    {
                        true => true,
                        false => false,
                        _=> throw new InvalidCastException(nameof(Value)),
                    };

                } else
                {
                    if (valueType.IsEnum)
                    {
                        throw new InvalidCastException(nameof(valueType));

                    } else
                    {
                        if (valueType == typeof(char))
                        {
                            return Value switch
                            {
                                '1' => true,
                                '0' => false,
                                _ => throw new InvalidCastException(nameof(Value)),
                            };

                        } else
                        {
                           return ValueTypeToBool(Value, valueType);
                        }
                      
                    }

                }                 

            }
            else
            {
                if (valueType.IsClass)
                {
                    if (valueType == typeof(string))
                    {
                        return (Value.ToString()?.ToLower()) switch
                        {
                            null => false,
                            "true" => true,
                            "false" => false,
                            "0" => false,
                            "1" => true,
                            _ => throw new InvalidCastException(nameof(valueType)),
                        };

                    }
                    else
                    {
                        if (valueType == typeof(ArrayList))
                        {
                            if (Value is not ArrayList value || value.Count == 0)
                                return false;
                            return true;

                        }
                        else
                        {
                            if (valueType == typeof(List<>))
                            {
                                if (Value is not List<object> value || value.Count == 0)
                                    return false;
                                return true;

                            } 
                            else
                            {
                                if (valueType == typeof(Dictionary<,>))
                                {
                                    if (Value is not Dictionary<object,object> value|| value.Count == 0) 
                                        return false;
                                    return true;

                                } 
                                else
                                {
                                    throw new InvalidCastException(nameof(valueType));  
                                }
                                   
                               
                            }

                        }

                    }


                }
                else
                { throw new InvalidCastException(nameof(valueType)); }
            }

            throw new InvalidCastException(nameof(valueType));
        }

        public static byte ToByte<T>(this T Value)
        {
            if (Value == null)
                throw new ArgumentNullException(nameof(Value));

            var typeName = typeof(T).Name.ToLower();

            _ = _types.TryGetValue(typeName, out var valueType);

            if (valueType == null)
                throw new ArgumentException("Wrong type", nameof(Value));

            if (valueType.IsClass || valueType.IsValueType)
            {
                var value = Value.ToString();

                if (value == null)
                    throw new ArgumentException("Wrong value", nameof(Value));

                if (valueType == typeof(bool))
                {
                    return Value switch
                    {
                        true => 1,
                        false => 0,
                        _=> throw new InvalidCastException()
                    };

                }

                if (value.Contains('.') || value.Contains(','))
                {
                    var num = value.Split(new char[] { '.', ',' });
                    var num1 = long.Parse(num[0]);
                    var num2 = long.Parse(num[1]);

                    if (num2 > 5)
                    {
                        value = (num1 + 1).ToString();
                    }
                    else
                    {
                        value = num1.ToString();
                    }
                }

                if (byte.TryParse(value, out byte _value))
                {
                    return _value;
                }
                else
                {
                    throw new InvalidCastException();
                }
            } else
            {
                return 0;

            }         

        }

        public static char ToChar<T>(this T Value)
        {
            throw new NotImplementedException();
        }

        public static DateTime ToDateTime<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static decimal ToDecimal<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static double ToDouble<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static short ToInt16<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static int ToInt32<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static long ToInt64<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static sbyte ToSByte<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static float ToSingle<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static string ToString<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static ushort ToUInt16<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static uint ToUInt32<T>(this T type)
        {
            throw new NotImplementedException();
        }

        public static ulong ToUInt64<T>(this T type)
        {
            throw new NotImplementedException();
        }

        private static bool ValueTypeToBool<T>(T value, Type type)
        {
           if (type== typeof(sbyte))
            {
                return value switch
                {
                    (sbyte)0 => false,
                    (sbyte)1 => true,
                    _ => throw new InvalidCastException($"{nameof(value)}")
                };
            } else
            {
                if (type == typeof(byte))
                {
                    return value switch
                    {
                        (byte)0 => false,
                        (byte)1 => true,
                        _ => throw new InvalidCastException($"{nameof(value)}")
                    };
                }
                else
                {

                    if (type == typeof(int))
                    {
                        return value switch
                        {
                            0 => false,
                            1 => true,
                            _ => throw new InvalidCastException($"{nameof(value)}")
                        };
                    }
                    else
                    {
                        if (type == typeof(uint))
                        {
                            return value switch
                            {
                                (uint)0 => false,
                                (uint)1 => true,
                                _ => throw new InvalidCastException($"{nameof(value)}")
                            };
                        }
                        else
                        {
                            if (type == typeof(long))
                            {
                                return value switch
                                {
                                    (long)0 => false,
                                    (long)1 => true,
                                    _ => throw new InvalidCastException($"{nameof(value)}")
                                };
                            }
                            else
                            {
                                if (type == typeof(float))
                                {
                                    return value switch
                                    {
                                        (float)0 => false,
                                        (float)1 => true,
                                        _ => throw new InvalidCastException($"{nameof(value)}")
                                    };
                                }
                                else
                                {
                                    if (type == typeof(short))
                                    {
                                        return value switch
                                        {
                                            (short)0 => false,
                                            (short)1 => true,
                                            _ => throw new InvalidCastException($"{nameof(value)}")
                                        };
                                    }
                                    else
                                    {
                                        if (type == typeof(ushort))
                                        {
                                            return value switch
                                            {
                                                (ushort)0 => false,
                                                (ushort)1 => true,
                                                _ => throw new InvalidCastException($"{nameof(value)}")
                                            };
                                        }
                                        else
                                        {
                                            if (type == typeof(ulong))
                                            {
                                                return value switch
                                                {
                                                    (ulong)0 => false,
                                                    (ulong)1 => true,
                                                    _ => throw new InvalidCastException($"{nameof(value)}")
                                                };
                                            }
                                            else
                                            {
                                                if (type == typeof(decimal))
                                                {
                                                    return value switch
                                                    {
                                                        (decimal)0 => false,
                                                        (decimal)1 => true,
                                                        _ => throw new InvalidCastException($"{nameof(value)}")
                                                    };
                                                }
                                                else
                                                {
                                                    if (type == typeof(double))
                                                    {
                                                        return value switch
                                                        {
                                                            (double)0 => false,
                                                            (double)1 => true,
                                                            _ => throw new InvalidCastException($"{nameof(value)}")
                                                        };
                                                    }
                                                    else
                                                    {
                                                        throw new InvalidCastException($"{nameof(value)}");

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            
        }
    }
}
