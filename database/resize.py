import os
import constants
import imageio
import numpy as np
from scipy.misc import imread, imsave, imresize
#from scipy import misc, ndimage

def resize(image, dim1, dim2):
	return imresize(image, (dim1, dim2))

def fileWalk(directory, destPath):
	try: 
		os.makedirs(destPath)
	except OSError:
		if not os.path.isdir(destPath):
			raise

	for subdir, dirs, files in os.walk(directory):
		for file in files:
			if len(file) <= 4 or file[-4:] != '.jpg':
				continue

			pic = imageio.imread(os.path.join(subdir, file))
			dim1 = len(pic)
			dim2 = len(pic[0])
			if dim1 > dim2:
				pic = np.rot90(pic)

			picResized = resize(pic,constants.DIM1, constants.DIM2)
			imsave(os.path.join(destPath, file), picResized)
		

def main():
	prepath = os.path.join(os.getcwd(), 'dataset-original')
	organicDir = os.path.join(prepath, 'organic')

	destPath = os.path.join(os.getcwd(), 'dataset-resized')
	try: 
		os.makedirs(destPath)
	except OSError:
		if not os.path.isdir(destPath):
			raise

	#GLASS
	fileWalk(organicDir, os.path.join(destPath, 'orangic'))


if __name__ == '__main__':
    main()