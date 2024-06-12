from PIL import Image

from deoldify import device
from deoldify.device_id import DeviceId
#choices:  CPU, GPU0...GPU7
device.set(device=DeviceId.GPU0)

import torch

if not torch.cuda.is_available():
    print('GPU not available.')
    
import fastai
from deoldify.visualize import *

torch.backends.cudnn.benchmark = True 

# если версия python >= 3.10 необходимо отдельно переназначить модуль Sized 
import collections
collections.Sized = collections.abc.Sized
# работаю в соседней папке, импортирую папку DeOldify
import sys
sys.path.append('./DeOldify')

image_path = 'штирлиц.jpg' 
colorizer = get_image_colorizer(artistic=True) 
colorizer.plot_transformed_image(image_path, render_factor=35, display_render_factor=True, figsize=(8,8))