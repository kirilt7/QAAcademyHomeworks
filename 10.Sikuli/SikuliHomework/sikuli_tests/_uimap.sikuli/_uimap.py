########################################################
# UI map for XYZ
########################################################
from sikuli import *
########################################################

class TA:
    label_GoogleInput=Pattern("telerikAcademy\GoogleInput.png").targetOffset(-60,0)
    label_TelerikAcademy="telerikAcademy\TelerikAcademy.png"

class DD:
    button_Oslo="dragAndDrop\Oslo.png"
    button_Copenhagen = "dragAndDrop\Copenhagen.png"
    button_Madrid = "dragAndDrop\Madrid.png"
    button_Rome = "dragAndDrop\Rome.png"
    button_Seoul = "dragAndDrop\Seoul.png"
    button_Stockholm = "dragAndDrop\Stockholm.png"
    button_Washington = "dragAndDrop\Washington.png"
    button_Norway = "dragAndDrop\Norway.png"
    button_Denmark = "dragAndDrop\Denmark.png"
    button_Spain = "dragAndDrop\Spain.png"
    button_Italy = "dragAndDrop\Italy.png"
    button_SouthKorea = "dragAndDrop\SouthKorea.png"
    button_Sweden = "dragAndDrop\Sweden.png"
    button_UnitedStates = "dragAndDrop\UnitedStates.png"
    button_NorwayOslo = "dragAndDrop\NorwayOslo.png"
    button_SwedenStockholm = "dragAndDrop\SwedenStockholm.png"
    button_DenmarkCopenhagen = "dragAndDrop\DenmarkCopenhagen.png"
    button_SpainMadrid = "dragAndDrop\SpainMadrid.png"
    button_ItalyRome = "dragAndDrop\ItalyRome.png"
    button_SouthKoreaSeoul = "dragAndDrop\SouthKoreaSeoul.png"
    button_UnitedStatesWashington = "dragAndDrop\UnitedStatesWashington.png"

class Skype:
    button_Search="skype\Search.png"
    button_TelerikQAAcademy="skype\TelerikQAAcademy.png"
    button_SendMessage="skype\SendMessage.png"
    
class Minimize:
    button_Minimize="minimize\Minimize.png"

class Calc:
    button_Plus="calc\Plus.png"
    button_Minus="calc\Minus.png"
    button_Multiply="calc\Multiply.png"
    button_Divide="calc\Divide.png"
    button_One="calc\One.png"
    button_Two="calc\Two.png"
    button_Zero="calc\Zero.png"
    button_Equal="calc\Equal.png"
    label_ResultOne="calc\ResultOne.png"
    label_ResultTwo="calc\ResultTwo.png"
    label_CannotDivideByZero="calc\CannotDivideByZero.png"
    