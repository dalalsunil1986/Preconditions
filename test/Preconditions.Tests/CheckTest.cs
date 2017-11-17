﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Preconditions.Tests
{
    public class CheckTest
    {
        #region Check.NotNull

        [Fact(DisplayName = "When the ref is null throws ArgumentNullException")]
        public void When_reference_is_null_Throws_ArgumentNullException()
        {
            object reference = null;

            Assert.Throws<ArgumentNullException>(nameof(reference), () => Check.NotNull(reference, nameof(reference)));
        }

        [Fact(DisplayName = "When the ref is not null returns the ref")]
        public void When_reference_is_not_null_Returns_reference()
        {
            object reference = new object();

            Assert.Same(reference, Check.NotNull(reference, nameof(reference)));
        }

        #endregion

        #region Check.NotEmpty : ICollection

        [Fact(DisplayName = "When the collection is null throws ArgumentNullException")]
        public void When_collection_is_null_Throws_ArgumentNullException()
        {
            ICollection<int> collection = null;

            Assert.Throws<ArgumentNullException>(nameof(collection), () => Check.NotEmpty(collection, nameof(collection)));
        }

        [Fact(DisplayName = "When the collection has no element throws ArgumentException")]
        public void When_collection_has_no_element_Throws_ArgumentException()
        {
            ICollection<int> collection = new List<int>();

            Assert.Throws<ArgumentException>(nameof(collection), () => Check.NotEmpty(collection, nameof(collection)));
        }

        [Fact(DisplayName = "When the collection is not empty returns the collection")]
        public void When_collection_is_not_empty_Returns_collection()
        {
            ICollection<int> collection = new List<int> { 1, 2, 3};

            Assert.Same(collection, Check.NotEmpty(collection, nameof(collection)));
        }

        #endregion

        #region Check.NotEmpty : IEnumerable

        [Fact(DisplayName = "When the enumerable is null throws ArgumentNullException")]
        public void When_enumerable_is_null_Throws_ArgumentNullException()
        {
            IEnumerable<int> enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable has no element throws ArgumentException")]
        public void When_enumerable_has_no_element_Throws_ArgumentException()
        {
            IEnumerable<int> enumerable = new List<int>();

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable is not empty returns the enumerable")]
        public void When_enumerable_is_not_empty_Returns_enumerable()
        {
            IEnumerable<int> enumerable = new List<int> { 1, 2, 3 };

            Assert.Same(enumerable, Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        #endregion

        #region Check.HasNoNulls

        [Fact(DisplayName = "When the enumerable 2 is null throws ArgumentNullException")]
        public void When_enumerable2_is_null_Throws_ArgumentNullException()
        {
            IEnumerable<string> enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable contains at least one null element throws ArgumentException")]
        public void When_enumerable_contains_one_element_Throws_ArgumentException()
        {
            IEnumerable<string> enumerable = new List<string> { "1", null, "3" };

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable does not contain any null element returns the enumerable")]
        public void When_enumerable_contains_no_null_element_Returns_enumerable()
        {
            IEnumerable<string> enumerable = new List<string> { "1", "2", "3" };

            Assert.Same(enumerable, Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        #endregion

        #region NullableButNotEmpty

        [Fact(DisplayName = "When the string is empty throws ArgumentException")]
        public void When_string_is_empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NullableButNotEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is null returns null")]
        public void When_string_is_null_Returns_null()
        {
            string text = null;

            Assert.Same(text, Check.NullableButNotEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is not null returns the string")]
        public void When_string_is_not_null_Returns_string()
        {
            string text = "PSG";

            Assert.Same(text, Check.NullableButNotEmpty(text, nameof(text)));
        }

        #endregion

        #region NotNullOrEmpty

        [Fact(DisplayName = "When the string 2 is empty throws ArgumentException")]
        public void When_string_2_is_empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NotNullOrEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is null throws ArgumentNullException")]
        public void When_string_is_null_Throws_ArgumentNullException()
        {
            string text = null;

            Assert.Throws<ArgumentNullException>(nameof(text), () => Check.NotNullOrEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string 2 is not null returns the string")]
        public void When_string_2_is_not_null_Returns_string()
        {
            string text = "PSG";

            Assert.Same(text, Check.NotNullOrEmpty(text, nameof(text)));
        }

        #endregion

        #region FileExists

        [Fact(DisplayName = "When file is null throws ArgumentNullException")]
        public void When_file_is_null_Throws_ArgumentNullException()
        {
            string file = null;

            Assert.Throws<ArgumentNullException>(nameof(file), () => Check.FileExists(file, nameof(file)));
        }

        [Fact(DisplayName = "When file does not exist throws ArgumentException")]
        public void When_file_does_not_exist_Throws_ArgumentException()
        {
            string file = @"C:\PSG.fr";

            Assert.Throws<ArgumentException>(nameof(file), () => Check.FileExists(file, nameof(file)));
        }

        [Fact(DisplayName = "When file exists returns the file")]
        public void When_file_exists_Returns_file()
        {
            string file = typeof(CheckTest).GetTypeInfo().Assembly.Location;

            Assert.Same(file, Check.NotNullOrEmpty(file, nameof(file)));
        }

        #endregion

        #region DirectoryExists

        [Fact(DisplayName = "When directory is null throws ArgumentNullException")]
        public void When_directory_is_null_Throws_ArgumentNullException()
        {
            string dir = null;

            Assert.Throws<ArgumentNullException>(nameof(dir), () => Check.DirectoryExists(dir, nameof(dir)));
        }

        [Fact(DisplayName = "When directory does not exist throws ArgumentException")]
        public void When_directory_does_not_exist_Throws_ArgumentException()
        {
            string dir = @"C:\PSG\";

            Assert.Throws<ArgumentException>(nameof(dir), () => Check.DirectoryExists(dir, nameof(dir)));
        }

        [Fact(DisplayName = "When directory exists returns the directory")]
        public void When_directory_exists_Returns_directory()
        {
            string dir = Path.GetDirectoryName(typeof(CheckTest).GetTypeInfo().Assembly.Location);

            Assert.Same(dir, Check.NotNullOrEmpty(dir, nameof(dir)));
        }

        #endregion

        #region Positive

        [Fact(DisplayName = "Positive - When long is positive Returns long")]
        public void Positive_When_long_is_positive_Returns_long()
        {
            long number = 1L;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When long is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_long_is_negative_Throws_ArgumentOutOfRangeException()
        {
            long number = 0L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When int is positive Returns int")]
        public void Positive_When_int_is_positive_Returns_int()
        {
            int number = 1;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When int is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_int_is_negative_Throws_ArgumentOutOfRangeException()
        {
            int number = 0;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When short is positive Returns short")]
        public void Positive_When_short_is_positive_Returns_short()
        {
            short number = 1;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When short is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_short_is_negative_Throws_ArgumentOutOfRangeException()
        {
            short number = 0;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When sbyte is positive Returns sbyte")]
        public void Positive_When_sbyte_is_positive_Returns_sbyte()
        {
            sbyte number = 1;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When sbyte is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_sbyte_is_negative_Throws_ArgumentOutOfRangeException()
        {
            sbyte number = 0;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When decimal is positive Returns decimal")]
        public void Positive_When_decimal_is_positive_Returns_decimal()
        {
            decimal number = 0.1m;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When decimal is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_decimal_is_negative_Throws_ArgumentOutOfRangeException()
        {
            decimal number = 0m;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When double is positive Returns double")]
        public void Positive_When_double_is_positive_Returns_double()
        {
            double number = 0.1d;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When double is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_double_is_negative_Throws_ArgumentOutOfRangeException()
        {
            double number = 0d;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When float is positive Returns float")]
        public void Positive_When_float_is_positive_Returns_float()
        {
            float number = 0.1f;
            Assert.Equal(number, Check.Positive(number, nameof(number)));
        }

        [Fact(DisplayName = "Positive - When float is negative throws ArgumentOutOfRangeException")]
        public void Positive_When_float_is_negative_Throws_ArgumentOutOfRangeException()
        {
            float number = 0f;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number, nameof(number)));
        }

        #endregion

        #region Negative

        [Fact(DisplayName = "Negative - When long is negative Returns long")]
        public void Negative_When_long_is_negative_Returns_long()
        {
            long number = -1L;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When long is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_long_is_positive_Throws_ArgumentOutOfRangeException()
        {
            long number = 1L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When int is negative Returns int")]
        public void Negative_When_int_is_negative_Returns_int()
        {
            int number = -1;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When int is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_int_is_positive_Throws_ArgumentOutOfRangeException()
        {
            int number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When short is negative Returns short")]
        public void Negative_When_short_is_negative_Returns_short()
        {
            short number = -1;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When short is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_short_is_positive_Throws_ArgumentOutOfRangeException()
        {
            short number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When sbyte is negative Returns sbyte")]
        public void Negative_When_sbyte_is_negative_Returns_sbyte()
        {
            sbyte number = -1;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When sbyte is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_sbyte_is_positive_Throws_ArgumentOutOfRangeException()
        {
            sbyte number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When decimal is negative Returns decimal")]
        public void Negative_When_decimal_is_negative_Returns_decimal()
        {
            decimal number = -0.1m;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When decimal is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_decimal_is_positive_Throws_ArgumentOutOfRangeException()
        {
            decimal number = 1m;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When double is negative Returns double")]
        public void Negative_When_double_is_negative_Returns_double()
        {
            double number = -0.1d;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When double is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_double_is_positive_Throws_ArgumentOutOfRangeException()
        {
            double number = 1d;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "When float is negative Returns float")]
        public void Negative_When_float_is_negative_Returns_float()
        {
            float number = -0.1f;
            Assert.Equal(number, Check.Negative(number, nameof(number)));
        }

        [Fact(DisplayName = "Negative - When float is positive throws ArgumentOutOfRangeException")]
        public void Negative_When_float_is_positive_Throws_ArgumentOutOfRangeException()
        {
            float number = 1f;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number, nameof(number)));
        }

        #endregion

        #region Zero

        [Fact(DisplayName = "Zero - When long is zero Returns long")]
        public void Zero_When_long_is_zero_Returns_long()
        {
            long number = 0L;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When long is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_long_is_positive_Throws_ArgumentOutOfRangeException()
        {
            long number = 1L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When long is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_long_is_negative_Throws_ArgumentOutOfRangeException()
        {
            long number = -1L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When int is zero Returns int")]
        public void Zero_When_int_is_zero_Returns_int()
        {
            int number = 0;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When int is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_int_is_positive_Throws_ArgumentOutOfRangeException()
        {
            int number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When int is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_int_is_negative_Throws_ArgumentOutOfRangeException()
        {
            int number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When short is zero Returns short")]
        public void Zero_When_short_is_zero_Returns_short()
        {
            short number = 0;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When short is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_short_is_positive_Throws_ArgumentOutOfRangeException()
        {
            short number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When short is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_short_is_negative_Throws_ArgumentOutOfRangeException()
        {
            short number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When sbyte is zero Returns sbyte")]
        public void Zero_When_sbyte_is_zero_Returns_sbyte()
        {
            sbyte number = 0;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When sbyte is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_sbyte_is_positive_Throws_ArgumentOutOfRangeException()
        {
            sbyte number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When sbyte is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_sbyte_is_negative_Throws_ArgumentOutOfRangeException()
        {
            sbyte number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When decimal is zero Returns decimal")]
        public void Zero_When_decimal_is_zero_Returns_decimal()
        {
            decimal number = -0.0m;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When decimal is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_decimal_is_positive_Throws_ArgumentOutOfRangeException()
        {
            decimal number = 1m;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When decimal is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_decimal_is_negative_Throws_ArgumentOutOfRangeException()
        {
            decimal number = -1m;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When double is zero Returns double")]
        public void Zero_When_double_is_zero_Returns_double()
        {
            double number = 0.0d;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When double is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_double_is_positive_Throws_ArgumentOutOfRangeException()
        {
            double number = 1d;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When double is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_double_is_negative_Throws_ArgumentOutOfRangeException()
        {
            double number = -1d;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When float is zero Returns float")]
        public void Zero_When_float_is_zero_Returns_float()
        {
            float number = -0.0f;
            Assert.Equal(number, Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When float is positive throws ArgumentOutOfRangeException")]
        public void Zero_When_float_is_positive_Throws_ArgumentOutOfRangeException()
        {
            float number = 1f;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        [Fact(DisplayName = "Zero - When float is negative throws ArgumentOutOfRangeException")]
        public void Zero_When_float_is_negative_Throws_ArgumentOutOfRangeException()
        {
            float number = -1f;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Zero(number, nameof(number)));
        }

        #endregion
    }
}
