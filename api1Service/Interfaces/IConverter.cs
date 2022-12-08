namespace api1Service.Interfaces
{
    internal interface IConverter
    {
        bool ToBoolean<T>(T type);
        byte ToByte<T>(T type);
        char ToChar<T>(T type);
        DateTime ToDateTime<T>(T type);
        decimal ToDecimal<T>(T type);
        double ToDouble<T>(T type);
        short ToInt16<T>(T type);
        int ToInt32<T>(T type);
        long ToInt64<T>(T type);
        sbyte ToSByte<T>(T type);
        float ToSingle<T>(T type);
        string ToString<T>(T type);
        ushort ToUInt16<T>(T type);
        uint ToUInt32<T>(T type);
        ulong ToUInt64<T>(T type);
    }
}
