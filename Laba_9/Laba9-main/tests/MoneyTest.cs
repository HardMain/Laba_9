using System;
using System.Runtime.ExceptionServices;

namespace Lab9.tests
{
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void OperatorPlus_KopeksInt_returnMoneyObj()
        {
            Money money1 = new Money(4, 15);
            int kop = 111;

            Money expected = new Money(5, 26);

            Money result = new Money();
            result = money1.PlusKopeks(kop);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorMinus_KopeksIntAndMoneyObj_MoneyObj()
        {
            Money money1 = new Money(2, 40);
            int kopeks = 325;
            Money expected = new Money(0, 85);

            Money result = new Money();
            result = kopeks - money1;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorMinus_KopeksIntAndMoneyObj_returnFreeMoneyObj()
        {
            Money money1 = new Money(2, 40);
            int kopeks = 125;
            Money expected = new Money();

            Money result = new Money();
            result = kopeks - money1;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorMinus_MoneyObjAndKopeksInt_MoneyObj()
        {
            Money money1 = new Money(4, 25);
            int kopeks = 325;
            Money expected = new Money(1, 0);

            Money result = new Money(money1 - kopeks);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorMinus_MoneyObjAndKopeksInt_returnFreeMoneyObj()
        {
            Money money1 = new Money(2, 25);
            int kopeks = 325;
            Money expected = new Money();

            Money result = new Money(money1 - kopeks);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorPlus_KopeksIntAndMoneyObj_MoneyObj()
        {
            Money money1 = new Money(2, 40);
            int kopeks = 101;
            Money expected = new Money(3, 41);

            Money result = new Money();
            result = kopeks + money1;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorPlus_MoneyObjAndKopeksInt_MoneyObj()
        {
            Money money1 = new Money(4, 25);
            int kopeks = 325;
            Money expected = new Money(7, 50);

            Money result = new Money(money1 + kopeks);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorIncrement_MoneyObj()
        {
            Money money1 = new Money(4, 25);
            Money expected = new Money(4, 26);

            money1++;
            Money result = money1;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OperatorDecrement_MoneyObj()
        {
            Money money1 = new Money(4, 25);
            Money expected = new Money(4, 24);

            money1--;
            Money result = money1;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void MethodRub_GetMoneyObj_returnRub()
        {
            Money money = new Money(3, 74);
            int expected = 3;

            int reslt = money.Rub;
            Assert.AreEqual(expected, reslt);
        }
        [TestMethod]
        public void MethodKop_GetSMoneyObj_returnKop()
        {
            Money money = new Money(3, 74);
            int expected = 74;

            int reslt = money.Kop;
            Assert.AreEqual(expected, reslt);
        }
        [TestMethod]
        public void MethodRub_SetNotRightRub_notReturnRub()
        {
            Money money = new Money();
            money.Rub = -4;
            int expected = 0;

            int reslt = money.Rub;
            Assert.AreEqual(expected, reslt);
        }
        [TestMethod]
        public void MethodKop_SetNotRightKop_notReturnKop()
        {
            Money money = new Money();
            money.Rub = 1;
            money.Kop = -115;
            int expected = 0;

            int reslt = money.Kop;
            Assert.AreEqual(expected, reslt);
        }
        [TestMethod]
        public void ImplicitMoneyConvertion_MoneyObjConvert_int()
        {
            Money money = new Money(3, 74);
            int expected = 3;

            int reslt = (int)money;
            Assert.AreEqual(expected, reslt);
        }
        [TestMethod]
        public void ExplicitMoneyConvertion_MoneyObjConvert_double()
        {
            Money money = new Money(3, 74);
            double expected = 0.74;

            double reslt = money;
            Assert.AreEqual(expected, reslt);
        }
    }

    [TestClass]
    public class MoneyArrayTest
    {
        [TestMethod]
        public void MoneyArrayConstructor_ValidInitialization()
        {
            int expected = 5;

            MoneyArray array;
            using (TextReader reader = new StringReader("5"))
            {
                Console.SetIn(reader);
                array = new MoneyArray();
            }

            int result = array.Length();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FillRandom_ValidFill()
        {
            MoneyArray array = new MoneyArray(5);
            bool expected = false;

            bool result = false;
            array.FillRandom();
            for (int i = 0; i < array.Length(); i++)
            {
                if (array[i] == null)
                {
                    result = true;
                    break;
                }
            }

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FillManual_ValidFill()
        {
            MoneyArray expected = new MoneyArray(5);

            expected[0] = new Money(1, 15);
            expected[1] = new Money(2, 40);
            expected[2] = new Money(3, 80);
            expected[3] = new Money(4, 125);
            expected[4] = new Money(8, 105);

            MoneyArray result = new MoneyArray(5);

            string input = "1\n15\n2\n40\n3\n80\n4\n125\n8\n105";

            using (TextReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                result.FillManual();
            }

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FindMax_ValidFindMin()
        {
            MoneyArray array = new MoneyArray(3);
            array[0] = new Money(5, 27);
            array[1] = new Money(8, 20);
            array[2] = new Money(4, 80);

            Money expectedMsg = new Money(4, 80);

            Money result = array.FindMin();

            Assert.AreEqual(expectedMsg, result);
        }
        [TestMethod]
        public void OperatorIndex_ValidGetValue_ReturnMoneyObject()
        {
            MoneyArray array = new MoneyArray(3);
            Money expected1 = new Money(1, 15);
            Money expected2 = new Money(2, 40);
            Money expected3 = new Money(3, 80);

            string input = "1\n15\n2\n40\n3\n80";

            using (TextReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                array.FillManual();
            }

            Money result1 = array[0];
            Money result2 = array[1];
            Money result3 = array[2];

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);

        }
        [TestMethod]
        public void OperatorIndexing_ValidSetValue()
        {
            Money expected1 = new Money(1, 15);
            Money expected2 = new Money(2, 40);
            Money expected3 = new Money(3, 80);

            MoneyArray result = new MoneyArray(3);
            result[0] = expected1;
            result[1] = expected2;
            result[2] = expected3;

            Assert.AreEqual(expected1, result[0]);
            Assert.AreEqual(expected2, result[1]);
            Assert.AreEqual(expected3, result[2]);
        }
        [TestMethod]
        public void OperatorIndexing_FailureGetValue_ReturnMoneyObject()
        {
            MoneyArray array = new MoneyArray(1);
            Money money = new Money();

            string input = "1";

            using (TextReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                money = array[-4];
            }
        }
        [TestMethod]
        public void OperatorIndexing_FailureSetValue_ReturnMoneyObject()
        {
            MoneyArray array = new MoneyArray(1);
            Money money = new Money(5, 15);

            string input = "1";

            using (TextReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                array[-1] = money;
            }
        }
    }
}