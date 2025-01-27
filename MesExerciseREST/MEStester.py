import requests

class AssertFail(Exception):

    def __init__(self,message):
        super().__init__(message)
        
class API:
    Base = "http://localhost:5269/apiv1/"

    def GetItemByKey(Key):
        return requests.get(API.Base + "GetItemByKey/" + Key)

    def SearchItemsByValue(Value):
        return requests.get(API.Base + "SearchItemsByValue/" + Value)

    def NewItem(Key,Value):
        return requests.post(API.Base + "NewItem",json = {"key":Key,"value":Value})

    def UpdateItem(Key,Value):
        return requests.put(API.Base + "UpdateItem",json = {"key":Key,"value":Value})

    def DeleteItem(Key):
        return requests.delete(API.Base + "DeleteItem/" + Key)


class Tester:

    def TestPost():
        #Put in an Item
        r = API.NewItem("ITEM1","VALUE1")
        assert(r.status_code == 200)
        #attempt to put in a double
        r = API.NewItem("ITEM1","VAlUE1")
        assert(r.status_code == 400)

    def TestGetItem():
        r = API.GetItemByKey("ITEM1")
        #assert that the get is valed
        assert(r.status_code == 200)
        assert(r.json()["key"] == "ITEM1")
        assert(r.json()["value"] == "VALUE1")
        #assert that empty value returns 400
        r = API.GetItemByKey("ITEM2")
        assert(r.status_code == 400)

    def TestUpdateItem():
        r = API.UpdateItem("ITEM2","UPDATE1")
        assert(r.status_code == 400)
        r = API.UpdateItem("ITEM1","UPDATE1")
        assert(r.status_code == 200)
        r = API.GetItemByKey("ITEM1")
        assert(r.json()["value"] == "UPDATE1")
        r = API.UpdateItem("ITEM1","VALUE1")
        assert(r.status_code == 200)
        r = API.GetItemByKey("ITEM1")
        assert(r.json()["value"] == "VALUE1")

    def TestSearchItemsByValue():
        for i in range(2,100):
            API.NewItem("ITEM" + str(i),"VALUE" + str(i))
        r = API.SearchItemsByValue("VALUE")
        assert(r.status_code == 200)
        print(r.json())

    def TestDelete():
        assert(API.DeleteItem("ITEM1").status_code == 200)
        assert(API.DeleteItem("ITEM1").status_code == 400)
        for i in range(2,100):
            assert(API.GetItemByKey("ITEM" + str(i)).status_code == 200)

Tester.TestPost()
Tester.TestGetItem()
Tester.TestUpdateItem()
Tester.TestSearchItemsByValue()
Tester.TestDelete()
