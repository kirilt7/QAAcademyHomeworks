import sikuli
from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

def RunBrowserToUrl(browser,toUrl):
    #TestAction("Start " +browser +" "+toUrl)
    sleep(0.5)
    type("d",KEY_WIN); sleep(1)
    type("r", KEY_WIN); sleep(1)
    type(browser+" "); sleep(1)
    type(toUrl); sleep(1)
    type(Key.ENTER)

def OpenTab(browser):
    sleep(0.5)
    type("r", KEY_WIN); sleep(1)
    type(browser+" "); sleep(1)
    type(Key.ENTER)

def RunSkype(location):
    sleep(0.5)
    type("d",KEY_WIN); sleep(1)
    type("r", KEY_WIN); sleep(1)
    type(location); sleep(1)
    type(Key.ENTER)
    
def RunCalculator():
    sleep(0.5)
    type("d",KEY_WIN); sleep(1)
    type("r", KEY_WIN); sleep(1)
    type("calc"); sleep(1)
    type(Key.ENTER)

def Exit():
    sleep(0.5)
    type(Key.F4, KEY_ALT)