import sys
import os
from PIL import Image
from deoldify import device
from deoldify.visualize import *

device.set(device=DeviceId.GPU0)

image_path = sys.argv[1]
colorizer = get_image_colorizer(artistic=True)
output_path = os.path.splitext(image_path)[0] + '_colored.png'
colorizer.save_transformed_image(output_path, render_factor=35)

print(output_path)