using System;
using System.Collections.Generic;

namespace Giver.Tests.Model {

    public class TestModel {
        public bool BoolProp { get; set; }
        public bool? NullableBoolProp { get; set; }
        public bool BoolField;
        public bool? NullableBoolField;

        public byte ByteProp { get; set; }
        public byte? NullableByteProp { get; set; }
        public byte ByteField;
        public byte? NullableByteField;

        public char? CharProp { get; set; }
        public char NullableCharProp { get; set; }
        public char? CharField;
        public char NullableCharField;

        public decimal DecimalProp { get; set; }
        public decimal? NullableDecimalProp { get; set; }
        public decimal DecimalField;
        public decimal? NullableDecimalField;

        public double DoubleProp { get; set; }
        public double? NullableDoubleProp { get; set; }
        public double DoubleField;
        public double? NullableDoubleField;

        public Int16 Int16Prop { get; set; }
        public Int16? NullableInt16Prop { get; set; }
        public Int16 Int16Field;
        public Int16? NullableInt16Field;

        public Int32 Int32Prop { get; set; }
        public Int32? NullableInt32Prop { get; set; }
        public Int32 Int32Field;
        public Int32? NullableInt32Field;

        public Int64 Int64Prop { get; set; }
        public Int64? NullableInt64Prop { get; set; }
        public Int64 Int64Field;
        public Int64? NullableInt64Field;

        public SByte SByteProp { get; set; }
        public SByte? NullableSByteProp { get; set; }
        public SByte SByteField;
        public SByte? NullableSByteField;

        public Single SingleProp { get; set; }
        public Single? NullableSingleProp { get; set; }
        public Single SingleField;
        public Single? NullableSingleField;

        public String StringProp { get; set; }
        public String StringField;

        public UInt16 UInt16Prop { get; set; }
        public UInt16? NullableUInt16Prop { get; set; }
        public UInt16 UInt16Field;
        public UInt16? NullableUInt16Field;

        public UInt32 UInt32Prop { get; set; }
        public UInt32? NullableUInt32Prop { get; set; }
        public UInt32 UInt32Field;
        public UInt32? NullableUInt32Field;

        public UInt64? UInt64Prop { get; set; }
        public UInt64 NullableUInt64Prop { get; set; }
        public UInt64? UInt64Field;
        public UInt64 NullableUInt64Field;

        public DateTime DateTimeProp { get; set; }
        public DateTime DateTimeField;
        public DateTime? NullableDateTimeProp { get; set; }
        public DateTime? NullableDateTimeField;

        public ICollection<Order> OrdersProp { get; set; }
        public Company CompanyField;
    }
}
