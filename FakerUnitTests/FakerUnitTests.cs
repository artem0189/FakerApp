using NUnit.Framework;
using System;
using System.Collections.Generic;
using FakerLib;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace FakerUnitTests
{
    public class Tests
    {
        private Faker _faker;
        private FakerConfig _config;

        [SetUp]
        public void Setup()
        {
            _config = new FakerConfig();
            _faker = new Faker(_config);
        }

        [Test]
        public void TestDefaultGenerators()
        {
            DefaultGeneratorsClass testClass = _faker.Create<DefaultGeneratorsClass>();

            Assert.NotZero(testClass.testInt);
            Assert.NotZero(testClass.testLong);
            Assert.NotZero(testClass.testFloat);
            Assert.NotZero(testClass.testDouble);
            Assert.NotZero(testClass.testChar);
            Assert.IsNotNull(testClass.testString);
            Assert.IsNotNull(testClass.testDate);
        }

        [Test]
        public void TestListGenerator()
        {
            ListGeneratorClass testClass = _faker.Create<ListGeneratorClass>();

            Assert.IsNotNull(testClass.testList);
            Assert.IsTrue(testClass.testList.Count > 0);
            Assert.NotZero(testClass.testList[0]);

            Assert.IsNotNull(testClass.testListWithDto);
            Assert.IsTrue(testClass.testListWithDto.Count > 0);
            Assert.IsNotNull(testClass.testListWithDto[0]);
        }

        [Test]
        public void TestProperties()
        {
            PropertiesClass testClass = _faker.Create<PropertiesClass>();

            Assert.NotZero(testClass.TestInt);
            Assert.IsNotNull(testClass.TestObject);
            Assert.Zero(testClass.TestDouble);
        }

        [Test]
        public void TestConstructors()
        {
            ConstructorsClass testClass = _faker.Create<ConstructorsClass>();

            Assert.NotZero(testClass.TestInt);
            Assert.NotZero(testClass.TestDouble);
        }

        [Test]
        public void TestNotDtoObject()
        {
            NotDtoClass testClass = _faker.Create<NotDtoClass>();

            Assert.IsNull(testClass);
        }

        [Test]
        public void TestNotDtoMember()
        {
            NotDtoMember testClass = _faker.Create<NotDtoMember>();

            Assert.NotZero(testClass.testInt);
            Assert.IsNull(testClass.testObject);
        }

        [Test]
        public void TestCustomGeneratorClass()
        {
            _config.Add<WithCustomGeneratorClass, int, CustomIntGenerator>(elem => elem.testInt);
            WithCustomGeneratorClass testClass = _faker.Create<WithCustomGeneratorClass>();

            Assert.AreEqual(-1, testClass.testInt);
            Assert.NotZero(testClass.TestDouble);
        }

        [Test]
        public void TestStruct()
        {
            DefaultStruct testStruct = _faker.Create<DefaultStruct>();

            Assert.NotZero(testStruct.testInt);
            Assert.NotZero(testStruct.TestDouble);
        }

        [Test]
        public void TestConstructorsStruct()
        {
            ConstructorsStruct testStruct = _faker.Create<ConstructorsStruct>();

            Assert.NotZero(testStruct.TestInt);
            Assert.NotZero(testStruct.TestChar);
        }

        [Test]
        public void TestCustomGeneratorStruct()
        {
            _config.Add<WithCustomGeneratorStruct, DateTime, CustomDateTimeGenerator>(elem => elem.Date);
            WithCustomGeneratorStruct testStruct = _faker.Create<WithCustomGeneratorStruct>();

            Assert.AreEqual(new DateTime(1995, 1, 1), testStruct.Date);
        }
    }

    [FakerCreate]
    public class DefaultGeneratorsClass
    {
        public int testInt;
        public long testLong;
        public float testFloat;
        public double testDouble;
        public char testChar;
        public string testString;
        public DateTime testDate;
    }

    [FakerCreate]
    public class ListGeneratorClass
    {
        public List<int> testList;
        public List<DefaultGeneratorsClass> testListWithDto;
    }

    [FakerCreate]
    public class PropertiesClass
    { 
        public int TestInt { get; set; }
        public DefaultGeneratorsClass TestObject { get; set; }
        public double TestDouble { get; }
    }

    [FakerCreate]
    public class ConstructorsClass
    {
        public int TestInt { get; }
        public double TestDouble { get; }

        public ConstructorsClass() { }

        public ConstructorsClass(int testInt, double testDouble)
        {
            TestInt = testInt;
            TestDouble = testDouble;
        }
    }

    public class NotDtoClass
    {
        public int testInt;
    }

    [FakerCreate]
    public class NotDtoMember
    {
        public int testInt;
        public NotDtoClass testObject;
    }

    public class CustomIntGenerator : IGenerator
    {
        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return -1;
        }
    }

    [FakerCreate]
    public class WithCustomGeneratorClass
    {
        public int testInt;
        public double TestDouble { get; }

        public WithCustomGeneratorClass(double testDouble)
        {
            TestDouble = testDouble;
        }
    }

    [FakerCreate]
    public struct DefaultStruct
    {
        public int testInt;
        public double TestDouble { get; set; }
    }

    [FakerCreate]
    public struct ConstructorsStruct
    {
        public int TestInt { get; }
        public char TestChar { get; }

        public ConstructorsStruct(int testInt)
        {
            TestInt = testInt;
            TestChar = 'A';
        }

        public ConstructorsStruct(int testInt, char testChar)
        {
            TestInt = testInt;
            TestChar = testChar;
        }
    }

    public class CustomDateTimeGenerator : IGenerator
    {
        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return new DateTime(1995, 1, 1);
        }
    }

    [FakerCreate]
    public struct WithCustomGeneratorStruct
    {
        public DateTime Date { get; }

        public WithCustomGeneratorStruct(DateTime date)
        {
            Date = date;
        }
    }
}