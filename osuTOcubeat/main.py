# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.


def change_int(x):
    notes = [1, 2, 3, 10, 20, 30, 100, 200, 300]
    for num in range(0, 9):
        if x < 512 * (num + 1) / 9:
            return notes[num]
    return 0
# Changing X coordinates to Cubeat numbers


def group_num(x):
    if (x % 10) == 1 or (x % 100) == 10 or x == 100:
        return 0
    elif (x % 10) == 2 or (x % 100) == 20 or x == 200:
        return 1
    else:
        return 2
# Returning column number of the note


def cubeat_sorting(li):
    return li[1]+group_num(li[0])
# Time -> Lane Sorting


def same_column(a, b):
    if a[1] != b[1]:
        return False
    if group_num(a[0]) != group_num(b[0]):
        return False

    return True


def combine_note(notes):
    val = None
    while len(notes) > 0:
        if val is None:
            val = notes.pop(0)
        else:
            val[0] += notes[0][0]
            notes.pop(0)

    return val
# Combining same column notes


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    f1 = open("score.txt", 'r', encoding='UTF-8')
    r = f1.readlines()
    f1.close()
    # Opening osu file

    while r[0] != "[HitObjects]\n":
        r.pop(0)
    r.pop(0)
    # Finding HitObjects part

    for i in range(0, len(r)):
        if len(r[i]) < 3:
            break

        r[i] = r[i].split(",")
        r[i].pop(4)
        r[i].pop(1)
    # Removing y, hit sound

    for i in range(0, len(r)):
        for j in range(0, 3):
            r[i][j] = int(r[i][j])
        r[i][0] = change_int(r[i][0])

        if r[i][2] < 128:
            r[i][2] = 0
            r[i][3] = 0
        else:
            r[i][2] = 1
            params = r[i][3].split(":")
            r[i][3] = int(params[0])
    r = sorted(r, key=cubeat_sorting)
    # Changing to INT

    new_list = []
    # Result List

    while len(r) > 0:
        temp = [r.pop(0)]
        while len(r) > 0 and same_column(temp[0], r[0]):
            temp.append(r.pop(0))
        # temp = Same Lane Notes

        i = len(temp)-1
        longNts = []
        while i >= 0:
            if temp[i][2] == 1:
                longNts.append(temp.pop(i))
            i -= 1

        if len(longNts) > 0:
            longNts = combine_note(longNts)
            new_list.append(longNts)
        # Combine LongNotes first

        if len(temp) > 0:
            temp = combine_note(temp)
            new_list.append(temp)
    # Combining same column notes

    f2 = open("cubeat.txt", 'w')

    for line in new_list:
        for i in range(0, 4):
            f2.write(str(line[i]))
            f2.write(" ")
        f2.write("\n")

    f2.close()
    # Writing cubeat score
