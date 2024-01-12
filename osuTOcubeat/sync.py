# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print("Input sync delta value: ", end='')
    delta = int(input())

    f1 = open("cubeat.txt", 'r', encoding='UTF-8')
    r = f1.readlines()
    f1.close()
    # Opening score file

    for i in range(0, len(r)):
        if len(r[i]) < 3:
            break
        r[i] = r[i].split(" ")
    # r[i] = one line

    for i in range(0, len(r)):
        for j in range(0, 4):
            r[i][j] = int(r[i][j])
        r[i][1] += delta

        if r[i][2] == 1:
            r[i][3] += delta
    # Changing Sync

    f2 = open("new_score.txt", 'w')

    for line in r:
        for i in range(0, 4):
            f2.write(str(line[i]))
            f2.write(" ")
        f2.write("\n")

    f2.close()
    # Writing new score