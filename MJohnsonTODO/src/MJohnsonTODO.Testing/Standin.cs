using NUnit.Framework;
using MJohnsonTODO.Model;
using MJohnsonTODO.EndPoints;

namespace MJohnsonTODO.Testing
{
	[TestFixture]
	public class Standin
	{
        TODOList testList = new TODOList();
        TODOListElement testListElement = new TODOListElement { Title = "Test Title", Details = "Test Details" };
		[Test]
		public void Adding_Element_To_Dictionary_Increases_Dictionary_Length()
		{
            testList.AddElement("Test Title One", "Test Details One");
			Assert.IsTrue(testList.getElementList().Count > 0);
		}

        [Test]
        public void Adding_Element_To_Dictionary_Adds_Correct_Element_To_Dictionary()
        {
            TODOListElement tempElement = new TODOListElement{Title="Test Temp", Details="Details Temp"};
            testList.AddElement(tempElement);
            TODOListElement secondTempElement = testList.getElement(tempElement.getMyId());           
            Assert.AreEqual(tempElement, secondTempElement);
        }

        [Test]
        public void Setting_Is_Done_On_Element_Works()
        {
            if (!testList.getElementList().ContainsKey(testListElement.getMyId()))
            {
                testList.AddElement(testListElement);
            }
              
            int key = testListElement.getMyId();
            DeleteItemEndPoint.SetIsDoneOnElement(new NewDeleteItemInputModel { ID = key }, testList);
            Assert.IsTrue(testList.getElement(key).IsDone == true);
        }

        [Test]
        public void Edit_Title_And_Content()
        {
            if(!testList.getElementList().ContainsKey(testListElement.getMyId()))
            {
                testList.AddElement(testListElement);
            }
            int key = testListElement.getMyId();
            string newDetails = "This is a Change in details";
            string newTitle = "This is a change in Title";

           testListElement = EditItemEndPoint.EditElementOfList(new NewEditInputModel { myID = testListElement.getMyId(), Details = newDetails ,
                Title = newTitle},testList);

           Assert.IsTrue(testListElement.Details.Equals(newDetails) && testListElement.Title.Equals(newTitle));
        }
	}
}