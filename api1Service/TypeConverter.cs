using api1Service.Interfaces;

namespace api1Service
{
    internal class TypeConverter : IConverter
    {
       private readonly Dictionary<string, Type> _types;

        public TypeConverter()
        {
            _types = new Dictionary<string, Type>(SetTypes());
        }

        public IDictionary<string, Type> GetTypes()
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
                ["object"] = typeof(object)
            };
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }
    }
}
