from PIL import Image
import pytesseract
import cv2
import os


def parse_image(image_uri: str, preprocess=None):
    image = cv2.imread(image_uri)
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

    if preprocess == "thresh":
        gray = cv2.threshold(gray, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]

    elif preprocess == "blur":
        gray = cv2.medianBlur(gray, 3)

    filename = "{}.png".format(os.getpid())
    cv2.imwrite(filename, gray)
    pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files\\Tesseract-OCR\\tesseract'
    text = pytesseract.image_to_string(Image.open(image_uri))
    os.remove(filename)
    return text