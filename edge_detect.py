import numpy
import cv2
from PIL import Image
filename = input("Enter an image file: ")
pic = numpy.array(cv2.imread(filename,0))

def convolution2d(image, kernel):
    m, n = kernel.shape
    if (m == n):
        y, x = image.shape
        y = y - m + 1
        x = x - m + 1
        new_image = numpy.zeros((y,x))
        for i in range(y):
            for j in range(x):
                new_image[i][j] = numpy.sum(image[i:i+m, j:j+m]*kernel)
    return new_image
kernel1 = numpy.array([[-10,-10,-10],[0,0,0],[10,10,10]])
output1 = convolution2d(pic,kernel1)
kernel2 = numpy.array([[-10,0,10],[-10,0,10],[-10,0,10]])
output2 = convolution2d(pic,kernel2)

output = output1+output2
img = Image.fromarray(output)
img.show()