import time
import urllib.request
import keyboard

status = 's'

def forward():
    global status
    if status!='f':
        print('forward')
        urllib.request.urlopen("http://192.168.1.1/f")
        status = 'f'

def backward():
    global status
    if status!='b':
        print('backward')
        urllib.request.urlopen("http://192.168.1.1/b")
        status = 'b'

def left():
    global status
    if status!='l':
        print('left')
        urllib.request.urlopen("http://192.168.1.1/l")
        status = 'l'

def right():
    global status
    if status!='r':
        print('right')
        urllib.request.urlopen("http://192.168.1.1/r")
        status = 'r'

def stop():
    global status
    if status!='s':
        print('stop')
        urllib.request.urlopen("http://192.168.1.1/")
        status = 's'

print('make sure you are connected to wifi "car-car"')

def dump(x):
    f = keyboard.KeyboardEvent('down',72,'up')
    d = keyboard.KeyboardEvent('down',80,'down')
    l = keyboard.KeyboardEvent('down',75,'left')
    r = keyboard.KeyboardEvent('down',77,'right')
    if x.event_type == 'down' and x.name==f.name:
        forward()
    elif x.event_type == 'down' and x.name==d.name:
        backward()
    elif x.event_type == 'down' and x.name==l.name:
        left()
    elif x.event_type == 'down' and x.name==r.name:
        right()
    else:
        stop()

keyboard.hook(dump)
keyboard.wait()