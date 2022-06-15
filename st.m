clear; clc; close all;

v1 = [-1,0]; v2 = [1,0]; v3 = [0,sqrt(3)];
verts = [v1;v2;v3];
l = 1000000;
pts = zeros(l,2);
pts(1,:) = [0,0];
for i = 2:l
    rv = verts(randi(3,1),:);
    pts(i,:) = (rv+pts(i-1,:))./2;
end
scatter(pts(:,1),pts(:,2),1,"filled");
axis equal;