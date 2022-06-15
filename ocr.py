import cv2
import numpy as np

def get_horizontal_projection(image):
    '''
    统计图片水平位置白色像素的个数
    '''
    #图像高与宽
    height_image, width_image = image.shape 
    height_projection = [0]*height_image
    for height in range(height_image):    # 按行去统计
        for width in range(width_image):  # 行中每个元素进行遍历
            if image[height, width] == 255:  # 该像素点为白色
                height_projection[height] += 1   # 该行白色像素点个数加1
    return height_projection

def get_vertical_projection(image): 
    '''
    统计图片垂直位置白色像素的个数
    '''
    #图像高与宽
    height_image, width_image = image.shape 
    width_projection = [0]*width_image # 列表的长度的为width_image，并且每个值都为0
    for width in range(width_image):
        for height in range(height_image):
            if image[height, width] == 255:
                width_projection[width] += 1
    return width_projection

def get_text_lines(projections):
    text_lines = []
    start = 0
    for index, projection in enumerate(projections):
        if projection>0 and start==0:
            start_location = index   # 有白字的开始行的索引
            start = 1
        if projection==0 and start==1:
            end_location = index    # 连续的，有白字的结束行的索引
            start = 0
            text_lines.append((start_location,end_location))  # 找到文本连续有白字的行开始位置、结束位置
    return text_lines

def get_text_word(projections):
    text_word = [ ]
    start = 0
    for index, projection in enumerate(projections):
        if projection>0 and start==0:
            start_location = index  # 列中，文字的开始位置
            start = 1
        if projection==0 and start==1:
            end_location = index    # 列中，文字的结束位置
            start = 0
            if len(text_word)>0 and start_location-text_word[-1][1]<3:
                text_word[-1] = (text_word[-1][0],end_location)
            else:
                text_word.append((start_location,end_location))  # 把每一个文字切出来了
    return text_word  

if __name__ == '__main__':
    img_color = cv2.imread('test.png')
    image = cv2.imread('test.png',cv2.IMREAD_GRAYSCALE)   # 读取图片，灰度图
    image = cv2.bitwise_not(image)
    print(image)
    print(image.shape)
    color = (0,0,255)
    thickness = 2
    #cv2.imshow('gray_image', image)
    #cv2.waitKey(0)
    #cv2.destroyAllWindows()
    height_image, width_image = image.shape
    _, binary_image = cv2.threshold(image,150,255,cv2.THRESH_BINARY_INV)   # 阈值处理，二值化，小于150像素的转为255，即非字区域转为255，大于150像素的转为0，即字区域转为白色
    height_projection = get_horizontal_projection(binary_image)  # 统计一行里面白色像素点个数
    text_lines = get_text_lines(height_projection)  # 获得文本行坐标
    for line_index, text_line in enumerate(text_lines):
        text_line_image = binary_image[text_line[0]:text_line[1], 0:width_image]  # 有字的文本行区域
        vertical_projection = get_vertical_projection(text_line_image)  # 有字的文本行区域中，统计每列有字的个数
        text_words = get_text_word(vertical_projection)  # 找到有字的文本行区域中，有字的列开始位置、结束位置
        if len(text_words)>0:
            start_point = (text_words[-1][1],text_line[1])
            end_point = (text_words[0][0],text_line[0])
            img_color = cv2.rectangle(img_color, start_point, end_point, color, thickness)
            #text_line_word_image = image[text_line[0]:text_line[1], text_words[0][0]:text_words[-1][1]]   # 左闭右开，第一行有字区域中
    cv2.imwrite("output.png",img_color)
            