import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *
    
class SmokeTests(unittest.TestCase):
    
    def setUp(self):
        pass

    def tearDown(self):
        pass
    
    def test_001_TelerikAcademyGoogleSearch(self):
        RunBrowserToUrl("chrome","www.google.com")
        wait(TA.label_GoogleInput, 10)
        click(TA.label_GoogleInput)
        type ("Telerik Academy")
        wait(TA.label_TelerikAcademy, 10)
    
    def test_002_CapitalsAndCountries(self):
        RunBrowserToUrl("chrome","http://www.dhtmlgoodies.com/scripts/drag-drop-custom/demo-drag-drop-3.html")
        wait(DD.button_Oslo, 10)
        dragDrop(DD.button_Oslo, DD.button_Norway)
        wait(DD.button_NorwayOslo, 10)
        dragDrop(DD.button_Stockholm, DD.button_Sweden)
        wait(DD.button_SwedenStockholm, 10)
        dragDrop(DD.button_Copenhagen, DD.button_Denmark)
        wait(DD.button_DenmarkCopenhagen, 10)
        dragDrop(DD.button_Seoul, DD.button_SouthKorea)
        wait(DD.button_SouthKoreaSeoul, 10)
        dragDrop(DD.button_Rome, DD.button_Italy)
        wait(DD.button_ItalyRome, 10)
        dragDrop(DD.button_Madrid, DD.button_Spain)
        wait(DD.button_SpainMadrid, 10)
        dragDrop(DD.button_Washington, DD.button_UnitedStates)
        wait(DD.button_UnitedStatesWashington, 10)
        
    def test_003_MinimizeWindows(self):
        OpenTab("chrome")
        OpenTab("chrome")
        OpenTab("chrome")
        click(Minimize.button_Minimize)
        click(Minimize.button_Minimize)
        click(Minimize.button_Minimize)
    
    def test_003_SentMessageViaSkype(self):
        RunSkype("C:\Program Files (x86)\Skype\Phone\Skype.exe") #change the path with yours. you must be logged in
        wait(Skype.button_Search, 10)
        type(Skype.button_Search, "Telerik QA Academy")
        wait(Skype.button_TelerikQAAcademy)
        click(Skype.button_TelerikQAAcademy)
        wait(Skype.button_SendMessage)
        type(Skype.button_SendMessage, "Message from Sikuli, batka" + Key.ENTER)
        

    def test_004_CheckCalcAddition(self):
        RunCalculator()
        wait(Calc.button_One, 10)
        click(Calc.button_One)
        click(Calc.button_Plus)
        click(Calc.button_One)
        click(Calc.button_Equal)
        wait(Calc.label_ResultTwo, 10)
        
    def test_005_CheckCalcSubstaction(self):
        RunCalculator()
        wait(Calc.button_One, 10)
        click(Calc.button_Two)
        click(Calc.button_Minus)
        click(Calc.button_One)
        click(Calc.button_Equal)
        wait(Calc.label_ResultOne, 10)

    def test_006_CheckCalcMultiplication(self):
        RunCalculator()
        wait(Calc.button_One, 10)
        click(Calc.button_One)
        click(Calc.button_Multiply)
        click(Calc.button_One)
        click(Calc.button_Equal)
        wait(Calc.label_ResultOne, 10)
        
    def test_007_CheckCalcDivision(self):
        RunCalculator()
        wait(Calc.button_One, 10)
        click(Calc.button_Two)
        click(Calc.button_Divide)
        click(Calc.button_Two)
        click(Calc.button_Equal)
        exists(Calc.label_ResultOne)
        
    def test_008_CheckCalcDivisionByZero(self):
        RunCalculator()
        wait(Calc.button_One, 10)
        click(Calc.button_Two)
        click(Calc.button_Divide)
        click(Calc.button_Zero)
        click(Calc.button_Equal)
        wait(Calc.label_CannotDivideByZero, 10)
        
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SmokeTests)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='SmokeTests Report' )
    runner.run(suite)
    outfile.close()

