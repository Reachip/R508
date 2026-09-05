INSERT INTO public.brand (brand_name) VALUES
                                   ('Apple'),
                                   ('Samsung'),
                                   ('Sony'),
                                   ('Nike'),
                                   ('Adidas'),
                                   ('Puma'),
                                   ('Zara'),
                                   ('H&M'),
                                   ('IKEA'),
                                   ('Bose'),
                                   ('Dell'),
                                   ('Lenovo'),
                                   ('Logitech'),
                                   ('Canon'),
                                   ('Philips'),
                                   ('Dyson'),
                                   ('Levi''s'),
                                   ('The North Face'),
                                   ('Xiaomi'),
                                   ('Sennheiser');

INSERT INTO public.product_type (product_type_name) VALUES
                                                 ('Smartphone'),
                                                 ('Laptop'),
                                                 ('Headphones'),
                                                 ('Wireless Earbuds'),
                                                 ('Television'),
                                                 ('Tablet'),
                                                 ('Smartwatch'),
                                                 ('Running Shoes'),
                                                 ('Sneakers'),
                                                 ('T-Shirt'),
                                                 ('Pants'),
                                                 ('Jacket'),
                                                 ('Backpack'),
                                                 ('Camera'),
                                                 ('Mechanical Keyboard'),
                                                 ('Wireless Mouse'),
                                                 ('Bluetooth Speaker'),
                                                 ('Stick Vacuum Cleaner'),
                                                 ('Desk Lamp'),
                                                 ('PC Monitor');

INSERT INTO public.product (
    product_name,
    description,
    photo_name,
    photo_uri,
    brand_id,
    product_type_id,
    actual_stock,
    min_stock,
    max_stock
)
VALUES
    -- 1. iPhone 15 Pro (Apple / Smartphone)
    (
        'iPhone 15 Pro 128 GB',
        'Smartphone powered by the A17 Pro chip with a titanium frame.',
        'iphone_15_pro.webp',
        'https://assets.example.com/products/apple/iphone-15-pro.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Apple'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Smartphone'),
        45, 10, 100
    ),

    -- 2. Galaxy S24 Ultra (Samsung / Smartphone)
    (
        'Galaxy S24 Ultra 256 GB',
        'Dynamic AMOLED 2X display with integrated S-Pen.',
        'galaxy_s24_ultra.webp',
        'https://assets.example.com/products/samsung/s24-ultra.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Samsung'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Smartphone'),
        30, 8, 80
    ),

    -- 3. WH-1000XM5 (Sony / Headphones)
    (
        'WH-1000XM5 Headphones',
        'Wireless over-ear headphones with industry-leading active noise cancellation.',
        'sony_wh1000xm5.webp',
        'https://assets.example.com/products/sony/wh-1000xm5.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Sony'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Headphones'),
        18, 5, 50
    ),

    -- 4. Air Zoom Pegasus (Nike / Running Shoes)
    (
        'Air Zoom Pegasus 40',
        'Versatile running shoes designed for daily training.',
        'nike_pegasus_40.webp',
        'https://assets.example.com/products/nike/pegasus-40.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Nike'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Running Shoes'),
        65, 15, 120
    ),

    -- 5. Ultraboost Light (Adidas / Sneakers)
    (
        'Ultraboost Light',
        'Responsive Boost cushioning featuring a supportive Primeknit upper.',
        'adidas_ultraboost.webp',
        'https://assets.example.com/products/adidas/ultraboost-light.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Adidas'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Sneakers'),
        40, 10, 90
    ),

    -- 6. QuietComfort Ultra (Bose / Wireless Earbuds)
    (
        'QuietComfort Ultra Earbuds',
        'True wireless earbuds delivering immersive spatial audio.',
        'bose_qc_ultra.webp',
        'https://assets.example.com/products/bose/qc-ultra-earbuds.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Bose'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Wireless Earbuds'),
        25, 5, 60
    ),

    -- 7. XPS 15 (Dell / Laptop)
    (
        'XPS 15 9530',
        'High-performance laptop featuring a 3.5K OLED display and Intel Core i7.',
        'dell_xps_15.webp',
        'https://assets.example.com/products/dell/xps-15.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Dell'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Laptop'),
        12, 3, 30
    ),

    -- 8. ThinkPad X1 Carbon (Lenovo / Laptop)
    (
        'ThinkPad X1 Carbon Gen 11',
        'Ultra-lightweight professional ultrabook built from carbon fiber.',
        'lenovo_x1_carbon.webp',
        'https://assets.example.com/products/lenovo/thinkpad-x1.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Lenovo'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Laptop'),
        15, 4, 35
    ),

    -- 9. MX Master 3S (Logitech / Wireless Mouse)
    (
        'MX Master 3S Performance',
        'Ergonomic wireless mouse with MagSpeed scrolling and quiet clicks.',
        'logitech_mx_master_3s.webp',
        'https://assets.example.com/products/logitech/mx-master-3s.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Logitech'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Wireless Mouse'),
        85, 20, 150
    ),

    -- 10. EOS R6 Mark II (Canon / Camera)
    (
        'EOS R6 Mark II Body Only',
        'Full-frame mirrorless camera with 24.2 MP and 4K 60p video.',
        'canon_eos_r6_mk2.webp',
        'https://assets.example.com/products/canon/eos-r6-mk2.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Canon'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Camera'),
        8, 2, 20
    ),

    -- 11. V15 Detect (Dyson / Stick Vacuum Cleaner)
    (
        'V15 Detect Total Clean',
        'Cordless vacuum cleaner with illumination laser and HEPA filtration.',
        'dyson_v15_detect.webp',
        'https://assets.example.com/products/dyson/v15-detect.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Dyson'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Stick Vacuum Cleaner'),
        22, 5, 50
    ),

    -- 12. 501 Original Jeans (Levi's / Pants)
    (
        '501 Original Fit Jeans',
        'Iconic straight fit in 100% cotton denim with button fly.',
        'levis_501_original.webp',
        'https://assets.example.com/products/levis/501-original.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Levi''s'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Pants'),
        110, 25, 200
    ),

    -- 13. Nuptse 1996 Jacket (The North Face / Jacket)
    (
        '1996 Retro Nuptse Jacket',
        'Packable down jacket filled with 700-fill goose down.',
        'tnf_nuptse_1996.webp',
        'https://assets.example.com/products/northface/nuptse-1996.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'The North Face'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Jacket'),
        19, 5, 45
    ),

    -- 14. Borealis Backpack (The North Face / Backpack)
    (
        'Borealis Classic Backpack',
        '28-liter volume with FlexVent suspension system and laptop compartment.',
        'tnf_borealis.webp',
        'https://assets.example.com/products/northface/borealis.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'The North Face'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Backpack'),
        50, 10, 100
    ),

    -- 15. Tertial Lamp (IKEA / Desk Lamp)
    (
        'TERTIAL Work Lamp',
        'Articulated steel architect lamp with desk clamp.',
        'ikea_tertial.webp',
        'https://assets.example.com/products/ikea/tertial.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'IKEA'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Desk Lamp'),
        140, 30, 250
    ),

    -- 16. Bravia XR A80L (Sony / Television)
    (
        'Bravia XR 55A80L OLED TV',
        '55-inch 4K 120Hz OLED TV with Cognitive Processor XR and Google TV.',
        'sony_bravia_a80l.webp',
        'https://assets.example.com/products/sony/bravia-a80l.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Sony'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Television'),
        7, 2, 20
    ),

    -- 17. Hue Go (Philips / Desk Lamp)
    (
        'Hue Go V2 Portable Smart Lamp',
        'Portable White & Color Ambiance smart light compatible with Zigbee/Bluetooth.',
        'philips_hue_go.webp',
        'https://assets.example.com/products/philips/hue-go-v2.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Philips'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Desk Lamp'),
        35, 8, 70
    ),

    -- 18. Redmi Note 13 (Xiaomi / Smartphone)
    (
        'Redmi Note 13 4G',
        '120Hz AMOLED display, 108 MP main camera, and 33W fast charging.',
        'xiaomi_redmi_note_13.webp',
        'https://assets.example.com/products/xiaomi/redmi-note-13.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Xiaomi'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Smartphone'),
        75, 15, 150
    ),

    -- 19. Momentum 4 (Sennheiser / Headphones)
    (
        'Momentum 4 Wireless',
        'Audiophile-inspired circum-aural headphones with up to 60-hour battery life.',
        'sennheiser_momentum_4.webp',
        'https://assets.example.com/products/sennheiser/momentum-4.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Sennheiser'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Headphones'),
        14, 4, 30
    ),

    -- 20. Galaxy Tab S9 (Samsung / Tablet)
    (
        'Galaxy Tab S9 Wi-Fi 128 GB',
        '11-inch Dynamic AMOLED 2X IP68-rated tablet with included S-Pen.',
        'samsung_tab_s9.webp',
        'https://assets.example.com/products/samsung/tab-s9.webp',
        (SELECT brand_id FROM public.brand WHERE brand_name = 'Samsung'),
        (SELECT product_type_id FROM public.product_type WHERE product_type_name = 'Tablet'),
        20, 5, 40
    );
