import React from 'react';

/**
 * Container to Inject Dependencies for services.
 * It primary purpose is to facilitate selection of fields to be rendered.
 * @param {sales_Service} a - Injected Sevice into DI container.
 * @returns {service_container} service Container.
 */
const Sidebar = ({ products, selectedProduct, onSelectProduct }) => {
    return (
        <div style={{ border: '1px solid #ccc', padding: '10px', width: '200px', maxHeight: '300px', overflowY: 'auto' }}>
            <ul style={{ listStyle: 'none', padding: 0 }}>
                {products.map((product, index) => (
                    <li key={index}>
                        <label>
                            <input
                                type="checkbox"
                                name="products"
                                value={product}
                                checked= {selectedProduct === product}
                                onChange={() => onSelectProduct(product)}
                            />
                            {product['name']}
                        </label>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Sidebar;
