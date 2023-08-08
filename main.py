from cvzone.FaceDetectionModule import FaceDetector
from cvzone.HandTrackingModule import HandDetector
import cv2
import socket


cap = cv2.VideoCapture(0)
cap.set(3, 1920)
cap.set(4, 1080)

detector = FaceDetector(minDetectionCon=0.8)
detector2 = HandDetector(detectionCon=0.8, maxHands=2)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)#ref
serverAddressPort = ('127.0.0.1', 5052)#ref
serverAddressPort2 = ('127.0.0.1', 5053)
serverAddressPort3 = ('127.0.0.1', 5054)
serverAddressPort4 = ('127.0.0.1', 5055)

while True:
    success, img = cap.read()

    # Finding the faces
    img, bboxs = detector.findFaces(img)
    # Finding the hands
    hands, img = detector2.findHands(img)

    m = 0
    r = 0
    l = 0
    o = 0

    if bboxs:
        center = bboxs[0]['center']
        print(center)
        data = str.encode(str(center))#ref
        sock.sendto(data, serverAddressPort)#ref
        #print(data)

    if hands:
        # Hand 1
        hand1 = hands[0]
        handR1 = hands[0]['center']
        lmList1 = hand1["lmList"]  # List of 21 Landmark points
        bbox1 = hand1["bbox"]  # Bounding box info x,y,w,h
        centerPoint1 = hand1['center']  # center of the hand cx,cy
        handType1 = hand1["type"]  # Handtype Left or Right

        length1 = detector2.findDistance(lmList1[8][0:2], lmList1[4][0:2])
        if lmList1[12][1] < lmList1[9][1]:
            r = 1
        if lmList1[16][1] < lmList1[13][1]:
            l = 1
        if lmList1[20][1] < lmList1[17][1]:
            o = 1

        if length1[0] < 20 and r and l and o:
            Symbol = "OK"
        #     # print(Symbol)
        else:
            Symbol = "NO"
        #     # print(Symbol)

        data2 = str.encode(str(handR1))
        sock.sendto(data2, serverAddressPort2)
        data4 = str.encode(str(Symbol))
        sock.sendto(data4, serverAddressPort4)
        if len(hands) == 2:
            # Hand 2
            hand2 = hands[1]
            handL2 = hands[1]['center']
            lmList2 = hand2["lmList"]  # List of 21 Landmark points
            bbox2 = hand2["bbox"]  # Bounding box info x,y,w,h
            centerPoint2 = hand2['center']  # center of the hand cx,cy
            handType2 = hand2["type"]  # Hand Type "Left" or "Right"
            # print(hand2)
            # length, info, img = detector2.findDistance(lmList1[8][0:2], lmList2[8][0:2], img)
            # print(lmList1[8][0:2])
            # length1 = detector2.findDistance(lmList2[8][0:2], lmList2[12][0:2])
            # print(length1[0])
            # if length1[0] < 20:
            #     print("OK")
            # else:
            #     print("NO")

            data3 = str.encode(str(handL2))
            sock.sendto(data3, serverAddressPort3)
    cv2.imshow("image", img)
    cv2.waitKey(1)

