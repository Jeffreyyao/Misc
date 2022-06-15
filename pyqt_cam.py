import cv2
import sys
from PyQt5.QtWidgets import  QLabel, QApplication, QMainWindow
from PyQt5.QtCore import QThread, Qt, pyqtSignal, pyqtSlot
from PyQt5.QtGui import QImage, QPixmap

class Thread(QThread):
    changePixmap = pyqtSignal(QImage)

    def run(self):
        cap = cv2.VideoCapture(0)
        while True:
            ret, frame = cap.read()
            if ret:
                rgbImage = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
                rgbImage = cv2.flip(rgbImage,1)
                h, w, ch = rgbImage.shape
                bytesPerLine = ch * w
                convertToQtFormat = QImage(rgbImage.data, w, h, 
bytesPerLine, QImage.Format_RGB888)
                p = convertToQtFormat.scaled(640, 480, Qt.KeepAspectRatio)
                self.changePixmap.emit(p)


class Window(QMainWindow):
    def __init__(self):
        super().__init__()
        self.initUI()

    @pyqtSlot(QImage)
    def setImage(self, image):
        self.label.setPixmap(QPixmap.fromImage(image))

    def initUI(self):
        self.label = QLabel(self)
        self.label.resize(640, 480)
        self.setCentralWidget(self.label)
        th = Thread(self)
        th.changePixmap.connect(self.setImage)
        th.start()
        self.show()

if __name__=="__main__":
    app = QApplication(sys.argv)
    window = Window()
    app.exec()